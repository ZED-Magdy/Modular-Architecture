using ConnectionPoint.Core.Application.Dtos;

namespace ConnectionPoint.Taxing.Application.DTOs.Tax
{
    public class TaxDto : FullAuditedDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public TaxTypeDto TaxType { get; set; } = TaxTypeDto.Included;
        public bool IsDefault { get; set; }
    }
}
