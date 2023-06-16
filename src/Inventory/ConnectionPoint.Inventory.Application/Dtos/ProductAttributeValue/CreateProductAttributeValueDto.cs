namespace ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

public class CreateProductAttributeValueDto
{
    public string Name { get; set; }
    public Guid ProductAttributeId { get; set; }
}