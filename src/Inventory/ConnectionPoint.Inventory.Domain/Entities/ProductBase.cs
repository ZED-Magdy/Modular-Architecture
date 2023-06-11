using System.ComponentModel.DataAnnotations.Schema;
using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Inventory.Domain.Entities.Enums;

namespace ConnectionPoint.Inventory.Domain.Entities;

public abstract class ProductBase : FullAuditedEntity
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public decimal GrossPrice { get; set; }
    // (GrossPrice - Discount) - Taxes
    public decimal NetPrice { get; set; }
    [Column(TypeName = "jsonb")]
    public IList<Guid>? TaxesIds { get; set; } = null;
    public decimal? Discount { get; set; }
    public decimal? DiscountPrice { get; set; }
    public DiscountType DiscountType { get; set; }
    public bool AvailableOnShop { get; set; } = false;
}