using ConnectionPoint.Inventory.Application.Dtos.Category;

namespace ConnectionPoint.Inventory.Application.Dtos.Product;

public class ProductDto : ProductBaseDto
{
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// 0 = Single, 1 = Variant
    /// </summary>
    public ProductTypeDto ProductType { get; set; } = ProductTypeDto.Single;
    public Guid? ParentProduct { get; set; }
    public IList<ProductDto> Variants { get; set; } = new List<ProductDto>();
    public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    // public IList<ProductUnitQuantity> ProductUnitQuantities { get; set; } = new List<ProductUnitQuantity>();
}

public enum ProductTypeDto
{
    Single = 0,
    Variant = 1
}