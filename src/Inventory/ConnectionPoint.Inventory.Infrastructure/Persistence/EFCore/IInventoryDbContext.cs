using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Infrastructure.Persistence.EFCore;

public interface IInventoryDbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Deal>? Deals { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Unit>? Units { get; set; }
    public DbSet<ProductUnitQuantity>? ProductUnitQuantities { get; set; }
    public DbSet<ProductVariation>? ProductVariations { get; set; }
    public DbSet<Variation>? Variations { get; set; }
    public DbSet<ProductAttribute>? ProductAttributes { get; set; }
    
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}