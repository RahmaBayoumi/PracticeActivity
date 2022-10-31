using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
