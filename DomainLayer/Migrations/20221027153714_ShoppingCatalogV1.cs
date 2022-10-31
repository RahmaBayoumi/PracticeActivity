using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainLayer.Migrations
{
    public partial class ShoppingCatalogV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImgURL = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "IsActive", "ModifiedDate", "CreatedDate" },
                values: new object[,]
                {
                    { 100, "Fruits and Vegetables",true,DateTime.Now,DateTime.Now },
                     { 101, "Dairy" ,true,DateTime.Now,DateTime.Now},
                }
                );


            migrationBuilder.InsertData(
               table: "Product",
               columns: new[] { "CategoryId", "Name", "Price", "Quantity", "ImgURL", "IsActive", "ModifiedDate", "CreatedDate" },
               values: new object[,]
               {
                    {   100, "Apple", 25.0,100,"http://Img1URL",true,DateTime.Now,DateTime.Now},
                     { 101, "Dairy" ,20.0,20,"http://Img2URL",true,DateTime.Now,DateTime.Now},
               }
               );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
