using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductAttributeValue : FullAuditedEntityDto
{
    public string Name { get; set; }
    public Guid ProductAttributeId { get; set; }
    public ProductAttribute ProductAttribute { get; set; }
    public ICollection<Variation> Variations { get; set; }
}