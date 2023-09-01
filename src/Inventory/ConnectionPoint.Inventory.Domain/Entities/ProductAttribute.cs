using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductAttribute : FullAuditedEntity
{
    //example (Size, Color, etc.)
    public string Name { get; set; }
    public ICollection<ProductAttributeValue> Values { get; set; } = new List<ProductAttributeValue>();
    public ICollection<Variation> Variations { get; set; }
}