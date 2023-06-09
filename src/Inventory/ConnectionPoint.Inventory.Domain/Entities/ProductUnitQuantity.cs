namespace ConnectionPoint.Inventory.Domain.Entities;

public class ProductUnitQuantity
{
    public Guid ProductId { get; set; }
    public Guid UnitId { get; set; }
    public double Quantity { get; set; }
}