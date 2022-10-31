namespace ShoppingCatalog.API.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public CategoryDto Category { get; set; }

    }
}
