namespace ConnectionPoint.Inventory.Application.Dtos.Category;

public class CreateCategoryDto
{
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public Guid? ParentCategoryId { get; set; } = null;
}