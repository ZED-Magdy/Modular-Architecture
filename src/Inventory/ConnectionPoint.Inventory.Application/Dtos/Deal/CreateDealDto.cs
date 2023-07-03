namespace ConnectionPoint.Inventory.Application.Dtos.Deal;

public class CreateDealDto
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
    /// <summary>
    /// 0 = Percentage, 1 = Amount
    /// </summary>
    public DiscountTypeDto DiscountType { get; set; }
    public bool AvailableOnShop { get; set; } = false;
    public int TotalLimit { get; set; } = 0;
    public int PerUserLimit { get; set; } = 0;
    public DateTime StartsOn { get; set; } = DateTime.UtcNow;
    public DateTime EndsOn { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public IList<DayDto> AvailableOn { get; set; } = new List<DayDto>();
    public IList<Guid> ServicesIds { get; set; } = new List<Guid>();
    public IList<Guid> ProductsIds { get; set; } = new List<Guid>();
    public IList<Guid> DealsIds { get; set; } = new List<Guid>();
}