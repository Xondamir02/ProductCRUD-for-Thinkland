using ProductCRUD.Models;

namespace ProductCRUD.Managers;

public interface IProductManager
{
    Task<IEnumerable<ProductModel>> GetProductsAsync(ProductFilter filter);
    Task<ProductModel> GetProductByIdAsync(Guid id);
    Task<ProductModel> AddProductAsync(CreateProductModel product);
    Task<ProductModel> UpdateProductAsync(Guid productId, CreateProductModel product);
    Task DeleteProductAsync(Guid id);
}
