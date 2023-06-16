using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;

namespace ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

public class ProductAttributeValueDto : FullAuditedDto
{
    public string Name { get; set; }
    public Guid ProductAttributeId { get; set; }
    public ProductAttributeDto ProductAttribute { get; set; }
}