using ConnectionPoint.Core.Infrastructure.Persistence.EFCore;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Infrastructure.Persistence.EFCore;

public class InventoryDbContext : ModuleDbContext, IInventoryDbContext
{
    protected override string Schema { get; } = "inventory";
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Deal>? Deals { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Unit>? Units { get; set; }


    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProductUnitQuantity>()
            .HasKey(p => new {p.ProductId, p.UnitId});
        
        modelBuilder.Entity<Deal>()
            .HasIndex(b => b.AvailableOn)
            .HasMethod("gin");
        
        modelBuilder.Entity<Service>()
            .Property(s => s.EmployeesIds)
            .HasConversion(
                v =>  v == null ? "" : string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList());
        
        modelBuilder.Entity<Service>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v =>  v == null ? "" : string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList());

        modelBuilder.Entity<Product>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v => v == null ? "" : string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList());
        
        modelBuilder.Entity<Deal>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v =>  v == null ? "" : string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList());
    }
}