using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;

namespace ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

public class ProductAttributeValueDto : FullAuditedDto
{
    public string Name { get; set; }
    public Guid AttributeId { get; set; }
    public ProductAttributeDto Attribute { get; set; }
}