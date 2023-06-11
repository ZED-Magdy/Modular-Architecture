using ConnectionPoint.Core.Application.Dtos;

namespace ConnectionPoint.Inventory.Application.Dtos;

public class ProductBaseDto : FullAuditedDto
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
    public decimal? Discount { get; set; }
    public decimal? DiscountPrice { get; set; }
    /// <summary>
    /// 0 = Percentage, 1 = Amount
    /// </summary>
    public DiscountTypeDto DiscountType { get; set; }
    public bool AvailableOnShop { get; set; } = false;
}

public enum DiscountTypeDto
{
    Percentage,
    Amount
}