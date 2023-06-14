﻿using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Infrastructure.Persistence;

namespace ConnectionPoint.Inventory.Infrastructure.Persistence.EFCore;

public class InventoryRepository<TEntity> : EFCoreRepository<TEntity> where TEntity : FullAuditedEntityDto
{
    public InventoryRepository(InventoryDbContext dbContext) : base(dbContext)
    {
    }
}