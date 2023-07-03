using ConnectionPoint.Inventory.Application.Dtos.Category;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

namespace ConnectionPoint.Inventory.Application.Dtos.Product;

public class ProductDto : ProductBaseDto
{
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// 0 = Single, 1 = Variant
    /// </summary>
    public ProductTypeDto ProductType { get; set; } = ProductTypeDto.Single;
    public Guid? ParentProduct { get; set; }
    public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public List<VariationDto> Variations { get; set; } = new List<VariationDto>();
    // public IList<ProductUnitQuantity> ProductUnitQuantities { get; set; } = new List<ProductUnitQuantity>();
}
public record VariationDto(ICollection<ProductAttributeValueDto> AttributeValues, decimal Price, int Stock);

public enum ProductTypeDto
{
    Single = 0,
    Variant = 1
}