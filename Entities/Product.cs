using ProductCRUD.Models;

namespace ProductCRUD.Entities;

    public class Product
    {
     public  Guid Id { get; set; }
     public required string Title { get; set; }
     public required string Description { get; set; }
     public required decimal Price { get; set; }
    }
public static class ProductExtension
{
    public static ProductModel ToModel(this Product product)
    {
        return new ProductModel()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price
        };
    }
}

