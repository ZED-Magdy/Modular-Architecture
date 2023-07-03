using ConnectionPoint.Inventory.Application.Dtos.Category;

namespace ConnectionPoint.Inventory.Application.Dtos.Product;

public class CreateProductDto
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public decimal GrossPrice { get; set; }
    /// <summary>
    /// (GrossPrice - Discount) - Taxes
    /// </summary>
    public decimal NetPrice { get; set; }
    public IList<Guid> TaxesIds { get; set; } = new List<Guid>();
    public Guid? CouponId { get; set; }
    public bool AvailableOnShop { get; set; } = false;
    public string Barcode { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    /// <summary>
    ///  0 = Single, 1 = Variant
    /// </summary>
    public ProductTypeDto ProductType { get; set; } = ProductTypeDto.Single;
    public IList<Guid> CategoriesIds { get; set; } = new List<Guid>();
    public List<CreateVariationDto> Variations { get; set; } = new List<CreateVariationDto>();
}
public record CreateVariationDto(ICollection<Guid> AttributeValues, decimal Price, int Stock);