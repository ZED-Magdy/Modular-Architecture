using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Variation : FullAuditedEntity
{
    //example (XL, Red, etc.)
    public Guid ProductVariationId { get; set; }
    public ProductVariation ProductVariation { get; set; }
    public Guid AttributeId { get; set; }
    public ProductAttribute Attribute { get; set; }
    public Guid ValueId { get; set; }
    public ProductAttributeValue Value { get; set; }
}