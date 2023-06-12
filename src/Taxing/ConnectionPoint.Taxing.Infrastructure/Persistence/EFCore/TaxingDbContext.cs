using ConnectionPoint.Core.Infrastructure.Persistence.EFCore;
using ConnectionPoint.Taxing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Taxing.Infrastructure.Persistence.EFCore
{
    public class TaxingDbContext :ModuleDbContext, ITaxingDbContext
    {
        protected override string Schema { get; } = "Taxing";
        public TaxingDbContext(DbContextOptions<TaxingDbContext> options ):base (options)
        {
        }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Taxable> Taxables { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
