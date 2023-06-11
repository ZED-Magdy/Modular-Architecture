using ConnectionPoint.Inventory.Application.Dtos.Category;

namespace ConnectionPoint.Inventory.Application.Dtos.Product;

public class UpdateProductDto
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
    //public IList<Guid> TaxesIds { get; set; } = new List<Guid>();
    public decimal? Discount { get; set; }
    public decimal? DiscountPrice { get; set; }
    /// <summary>
    /// 0 = Percentage, 1 = Amount
    /// </summary>
    public DiscountTypeDto DiscountType { get; set; }
    public bool AvailableOnShop { get; set; } = false;
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    ///  0 = Single, 1 = Variant
    /// </summary>
    public ProductTypeDto ProductType { get; set; } = ProductTypeDto.Single;
    // public Guid? ParentProduct { get; set; }
    // public IList<ProductDto> Variants { get; set; } = new List<ProductDto>();
    // public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
}