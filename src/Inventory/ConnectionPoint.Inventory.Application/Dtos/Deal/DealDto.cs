using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Dtos.Service;

namespace ConnectionPoint.Inventory.Application.Dtos.Deal;

public class DealDto : ProductBaseDto
{
    public int TotalLimit { get; set; } = 0;
    public int PerUserLimit { get; set; } = 0;
    public DateTime StartsOn { get; set; } = DateTime.UtcNow;
    public DateTime EndsOn { get; set; } = DateTime.UtcNow;
    public IList<DayDto> AvailableOn { get; set; } = new List<DayDto>();
    public IList<ServiceDto> Services { get; set; } = new List<ServiceDto>();
    public IList<ProductDto> Products { get; set; } = new List<ProductDto>();
    public IList<DealDto> Deals { get; set; } = new List<DealDto>();
}