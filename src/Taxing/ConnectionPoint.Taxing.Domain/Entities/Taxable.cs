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
        public void Create(Guid taxableId, string taxableType, decimal Price, IList<Tax> taxes)
        {
            TaxableId = taxableId;
            TaxableType = taxableType;
            Taxes = taxes;
            GrossPrice = Price;
            foreach (var tax in Taxes)
            {
                if (tax.TaxType == TaxType.Included)
                {
                    NetPrice += Price / (1 + tax.Rate / 100);
                }
                else
                {
                    NetPrice += Price;
                }
            }
        }
    }
}
