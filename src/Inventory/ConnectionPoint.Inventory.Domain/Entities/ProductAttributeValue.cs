using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductAttributeValue : FullAuditedEntity
{
    public string Name { get; set; }
    public Guid AttributeId { get; set; }
    public ProductAttribute Attribute { get; set; }
    public ICollection<ProductVariation> Variations { get; set; }
}