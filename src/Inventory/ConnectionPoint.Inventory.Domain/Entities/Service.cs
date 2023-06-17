using System.ComponentModel.DataAnnotations.Schema;
using ConnectionPoint.Inventory.Domain.Entities.Enums;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Service : ProductBase
{
    public ServiceType ServiceType { get; set; } = ServiceType.Single;
    public IList<Category> Categories { get; set; } = new List<Category>();
    public IList<ServiceProduct> ServiceProducts { get; set; } = new List<ServiceProduct>();
    [Column(TypeName = "jsonb")]
    public IList<Guid>? EmployeesIds { get; set; }
}