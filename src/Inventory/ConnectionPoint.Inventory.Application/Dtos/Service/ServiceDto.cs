using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;

namespace ConnectionPoint.Inventory.Application.Dtos.Service;

public class ServiceDto : ProductBaseDto
{
    public ServiceTypeDto ServiceType { get; set; } = ServiceTypeDto.Single;
    public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public IList<Guid> EmployeesIds { get; set; } = new List<Guid>();
}
public enum ServiceTypeDto
{
    Combo,
    Single
}