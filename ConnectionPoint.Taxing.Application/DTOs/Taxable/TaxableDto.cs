using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Taxing.Application.DTOs.Tax;

namespace ConnectionPoint.Taxing.Application.DTOs.Taxable
{
    public class TaxableDto : FullAuditedDto
    {
        public Guid TaxableId { get; set; }
        public string TaxableType { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NetPrice { get; set; }
        public IList<TaxDto> Taxes { get; set; } = new List<TaxDto>();
    }
}
