using ConnectionPoint.Core.Application.Dtos;

namespace ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;

public class ProductAttributeDto : FullAuditedDto
{
    public string Name { get; set; }
}