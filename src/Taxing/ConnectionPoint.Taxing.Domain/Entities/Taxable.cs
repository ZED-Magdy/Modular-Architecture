using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Taxing.Domain.Entities.Enums;

namespace ConnectionPoint.Taxing.Domain.Entities
{
    public class Taxable : FullAuditedEntity
    {
        public Guid TaxableId { get; set; }
        public string TaxableType { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NetPrice { get; set; }
        public IList<Tax> Taxes { get; set; } = new List<Tax>();
        public Taxable() { }
        public static Taxable Create(Guid taxableId, string taxableType, decimal price, IList<Tax> taxes)
        {
            var taxable = new Taxable();
            taxable.TaxableId = taxableId;
            taxable.TaxableType = taxableType;
            taxable.Taxes = taxes;
            taxable.GrossPrice = 0;
            taxable.CalculateTaxes(price, taxes);
            return taxable;
        }

        public void CalculateTaxes(decimal price, IList<Tax> taxes)
        {
            foreach (var tax in taxes)
            {
                if (tax.TaxType == TaxType.Included)
                {
                    GrossPrice += price / (1 + tax.Rate / 100);
                }
                else
                {
                    GrossPrice += price;
                }
            }
        }
    }
}
