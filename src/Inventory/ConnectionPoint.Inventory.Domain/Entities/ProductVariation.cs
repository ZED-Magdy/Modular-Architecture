using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductVariation : FullAuditedEntity
{
    public Guid ProductId { get; set; } 
    public Product Product { get; set; } = null!;
    public ICollection<Variation> Variations { get; set; }
}