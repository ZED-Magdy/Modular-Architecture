using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Category : FullAuditedEntity
{
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public IList<Service> Services { get; set; } = new List<Service>();
    public IList<Product> Products { get; set; } = new List<Product>();
}