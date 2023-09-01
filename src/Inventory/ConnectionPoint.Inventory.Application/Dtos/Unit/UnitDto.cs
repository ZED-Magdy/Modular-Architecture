using ConnectionPoint.Core.Application.Dtos;

namespace ConnectionPoint.Inventory.Application.Dtos.Unit;

public class UnitDto : FullAuditedDto
{
    public string Name { get; set; } = string.Empty;
}