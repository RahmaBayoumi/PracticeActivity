using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCatalog.API.Models
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
