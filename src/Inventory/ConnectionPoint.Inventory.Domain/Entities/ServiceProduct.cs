using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ServiceProduct : FullAuditedEntity
{
    public Guid ServiceId { get; set; }
    public Guid ProductId { get; set; }
    //TODO: Add quantity
    public Product? Product { get; set; }
    public Service? Service { get; set; }
}