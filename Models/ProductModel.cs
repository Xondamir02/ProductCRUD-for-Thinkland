namespace ProductCRUD.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}
