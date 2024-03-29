﻿using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Unit : FullAuditedEntity
{
    public string Name { get; set; } = string.Empty;
    public IList<ProductUnitQuantity> ProductUnitQuantities { get; set; } = new List<ProductUnitQuantity>();
}