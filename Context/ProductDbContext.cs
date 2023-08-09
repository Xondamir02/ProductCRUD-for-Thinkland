using Microsoft.EntityFrameworkCore;
using ProductCRUD.Entities;

namespace ProductCRUD.Context;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }
}
