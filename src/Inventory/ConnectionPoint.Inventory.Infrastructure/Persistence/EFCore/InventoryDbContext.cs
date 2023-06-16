using ConnectionPoint.Core.Infrastructure.Persistence.EFCore;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

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
    public DbSet<ProductUnitQuantity>? ProductUnitQuantities { get; set; }
    public DbSet<ProductVariation>? ProductVariations { get; set; }
    public DbSet<Variation>? Variations { get; set; }
    public DbSet<ProductAttribute>? ProductAttributes { get; set; }


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
                v => v.Any() ? $"[{string.Join(",", v.Select(g => $"\"{g}\""))}]" : "[]",
                v => !string.IsNullOrEmpty(v)
                    ? JArray.Parse(v).Select(token => Guid.Parse(token.ToString())).ToList()
                    : new List<Guid>()
            );
        modelBuilder.Entity<Service>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v => v.Any() ? $"[{string.Join(",", v.Select(g => $"\"{g}\""))}]" : "[]",
                v => !string.IsNullOrEmpty(v)
                    ? JArray.Parse(v).Select(token => Guid.Parse(token.ToString())).ToList()
                    : new List<Guid>()
            );

        modelBuilder.Entity<Product>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v => v.Any() ? $"[{string.Join(",", v.Select(g => $"\"{g}\""))}]" : "[]",
                v => !string.IsNullOrEmpty(v)
                    ? JArray.Parse(v).Select(token => Guid.Parse(token.ToString())).ToList()
                    : new List<Guid>()
            );
        modelBuilder.Entity<Deal>()
            .Property(s => s.TaxesIds)
            .HasConversion(
                v => v.Any() ? $"[{string.Join(",", v.Select(g => $"\"{g}\""))}]" : "[]",
                v => !string.IsNullOrEmpty(v)
                    ? JArray.Parse(v).Select(token => Guid.Parse(token.ToString())).ToList()
                    : new List<Guid>()
            );
        modelBuilder.Entity<ProductVariation>()
            .HasKey(pv => pv.Id);

        modelBuilder.Entity<ProductVariation>()
            .HasOne(pv => pv.Product)
            .WithMany(p => p.Variations)
            .HasForeignKey(pv => pv.ProductId);

        modelBuilder.Entity<Variation>()
            .HasKey(v => v.Id);

        modelBuilder.Entity<Variation>()
            .HasOne(v => v.ProductVariation)
            .WithMany(pv => pv.Variations)
            .HasForeignKey(v => v.ProductVariationId);

        modelBuilder.Entity<ProductAttribute>()
            .HasKey(pa => pa.Id);

        modelBuilder.Entity<ProductAttribute>()
            .HasMany(pa => pa.Variations)
            .WithOne(v => v.Attribute)
            .HasForeignKey(v => v.AttributeId);

        modelBuilder.Entity<ProductAttributeValue>()
            .HasKey(pav => pav.Id);

        modelBuilder.Entity<ProductAttributeValue>()
            .HasMany(pav => pav.Variations)
            .WithOne(v => v.Value)
            .HasForeignKey(v => v.ValueId);
    }

    private IList<Guid> ConvertListToGuid(string? s)
    {
        Console.WriteLine(s);
        return !string.IsNullOrEmpty(s)
            ? s.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(guidString =>
                {
                    Guid.TryParse(guidString, out Guid guid);
                    return guid;
                })
                .ToList()
            : new List<Guid>();
    }
}