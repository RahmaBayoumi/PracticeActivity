using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class Product:BaseEntity
    {
      
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }

}
