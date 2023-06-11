using ConnectionPoint.Taxing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoint.Taxing.Infrastructure.Persistence.EFCore
{
    public interface ITaxingDbContext
    {
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Taxable> Taxables { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
