using ConnectionPoint.Inventory.Domain.Entities.Enums;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Service : ProductBase
{
    public ServiceType ServiceType { get; set; } = ServiceType.Single;
    public IList<Category> Categories { get; set; } = new List<Category>();
    public IList<ServiceProduct> ServiceProducts { get; set; } = new List<ServiceProduct>();
    public IList<Guid> EmployeesIds { get; set; } = new List<Guid>();
}