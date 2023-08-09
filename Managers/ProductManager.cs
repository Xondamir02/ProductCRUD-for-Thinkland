using Microsoft.EntityFrameworkCore;
using ProductCRUD.Context;
using ProductCRUD.Entities;
using ProductCRUD.Exceptions;
using ProductCRUD.Models;

namespace ProductCRUD.Managers;

public class ProductManager : IProductManager
{
    private readonly ProductDbContext _context;
    public ProductManager(ProductDbContext context)
    {
        _context = context;
    }

    public async  Task<ProductModel> AddProductAsync(CreateProductModel model)
    {
        var product = new Product
        {
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product.ToModel();
    }


    public async Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new ProductNotFoundException(id.ToString());
        }
        return product.ToModel();
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync(ProductFilter filter)
    {
        var query = _context.Products.AsQueryable();

        if(!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(p=>p.Title.Contains(filter.Title));

        if (!string.IsNullOrWhiteSpace(filter.Description))
            query = query.Where(p => p.Description.Contains(filter.Description));
        if (filter.FromPrice is not null)
            query = query.Where(p => p.Price >= filter.FromPrice);
        if (filter.ToPrice is not null)
            query = query.Where(p => p.Price <= filter.ToPrice);

        return await query.Select(p=> p.ToModel()).ToListAsync();
    }

    public async Task<ProductModel> UpdateProductAsync(Guid productId, CreateProductModel model)
    {
       var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id==productId);
        if (product == null) 
        { 
            throw new ProductNotFoundException(productId.ToString()); 
        } 
        product.Title = model.Title;
        product.Description = model.Description;
        product.Price = model.Price;

        await _context.SaveChangesAsync();

        return product.ToModel();
    }
    public async  Task DeleteProductAsync(Guid id)
    {
       var product = await _context.Products.FirstOrDefaultAsync(p => p.Id==id);
        if (product == null)
        {
            throw new ProductNotFoundException(id.ToString());
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

    }
}
