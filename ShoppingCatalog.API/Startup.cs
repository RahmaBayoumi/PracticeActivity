using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using ServiceLayer.CustomServices;
using ServiceLayer.ICustomServices;
using ShoppingCatalog.API.DbContexts;
using System;

namespace ShoppingCatalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                 {
                     var problemDetailsFactory = context.HttpContext.RequestServices
                     .GetRequiredService<ProblemDetailsFactory>();
                     var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext,context.ModelState);
                     problemDetails.Detail = "See the errors field for details.";
                     problemDetails.Instance = context.HttpContext.Request.Path;
                     var actionExecutingContext =
                     context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
                     if((context.ModelState.ErrorCount>0)&& (actionExecutingContext?.ActionArguments.Count==context.ActionDescriptor.Parameters.Count))
                     {
                         problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                         problemDetails.Title = "One or more validation errors occurred.";

                         return new UnprocessableEntityObjectResult(problemDetails)
                         {
                             ContentTypes = { "application/problem+json" }
                         };
                     }
                     problemDetails.Status = StatusCodes.Status400BadRequest;
                     problemDetails.Title = "One or more errors on input occurred.";
                     return new BadRequestObjectResult(problemDetails)
                     {
                         ContentTypes = { "application/problem+json" }
                     };
                 };
            
            }
            
            );

            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<Category>), typeof(CategoryRepository));
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

            services.AddDbContext<ShoppingCatalogDbContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=ShoppingCatalogDB;Trusted_Connection=True;");
            });

            services.AddScoped(typeof(ICustomServices<Category>), typeof(CategoryService));
            services.AddScoped(typeof(ICustomServices<Product>), typeof(ProductService));

            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTestService", Version = "v1", });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    appBuilder =>
                    {
                        appBuilder.Run(async context =>
                        {
                            context.Response.StatusCode = 500;
                            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                        });
                    });
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Catalog API V1");
                c.RoutePrefix = "";
            });
        }
    }
}
