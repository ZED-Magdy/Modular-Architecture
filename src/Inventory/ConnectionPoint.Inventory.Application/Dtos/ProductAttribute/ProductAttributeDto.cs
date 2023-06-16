using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

namespace ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;

public class ProductAttributeDto : FullAuditedDto
{
    public string Name { get; set; }
    public IList<ProductAttributeValueDto> Values { get; set; } = new List<ProductAttributeValueDto>();
}