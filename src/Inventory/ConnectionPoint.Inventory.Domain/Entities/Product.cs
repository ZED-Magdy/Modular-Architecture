using ConnectionPoint.Inventory.Domain.Entities.Enums;

namespace ConnectionPoint.Inventory.Domain.Entities;

public class Product : ProductBase
{
    public string Barcode { get; set; } = string.Empty;
    public ProductType ProductType { get; set; } = ProductType.Single;
    public Guid? ParentProduct { get; set; }
    public IList<ProductVariation> Variations { get; set; } = new List<ProductVariation>();
    public IList<Category> Categories { get; set; } = new List<Category>();
    public IList<ProductUnitQuantity> ProductUnitQuantities { get; set; } = new List<ProductUnitQuantity>();
    
    public Product CreateVariations(List<Dictionary<Guid, Guid>> variationAttributes)
    {
        Variations = new List<ProductVariation>();

        foreach (var attributes in variationAttributes)
        {
            var variation = new ProductVariation
            {
                ProductId = Id,
                Variations = new List<Variation>()
            };

            foreach (var attribute in attributes)
            {
                variation.Variations.Add(new Variation
                {
                    ProductVariation = variation,
                    AttributeId = attribute.Key,
                    ValueId = attribute.Value
                });
            }

            Variations.Add(variation);
        }
        return this;
    }
}