using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Deal : ProductBase
{
    public int TotalLimit { get; set; } = 0;
    public int PerUserLimit { get; set; } = 0;
    public DateTime StartsOn { get; set; } = DateTime.UtcNow;
    public DateTime EndsOn { get; set; } = DateTime.UtcNow;
    [Column(TypeName = "jsonb")]
    public IList<Day> AvailableOn { get; set; } = new List<Day>();
    public IList<Service> Services { get; set; } = new List<Service>();
    public IList<Product> Products { get; set; } = new List<Product>();
    public IList<Deal> Deals { get; set; } = new List<Deal>();
}