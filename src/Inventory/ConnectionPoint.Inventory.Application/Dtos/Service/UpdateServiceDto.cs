namespace ConnectionPoint.Inventory.Application.Dtos.Service;

public class UpdateServiceDto
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
    public bool Active { get; set; } = true;
    public ServiceTypeDto ServiceType { get; set; } = ServiceTypeDto.Single;
    public IList<Guid> EmployeesIds { get; set; } = new List<Guid>();
    public IList<Guid> CategoriesIds { get; set; } = new List<Guid>();
}