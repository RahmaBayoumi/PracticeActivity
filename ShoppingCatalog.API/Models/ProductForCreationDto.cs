using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCatalog.API.Models
{
    public class ProductForCreationDto
    {
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public int CategoryId { get; set; }
    }
}
