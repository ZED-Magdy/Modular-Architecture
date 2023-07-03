using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductVariation : FullAuditedEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public ICollection<ProductAttributeValue> AttributeValues { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}