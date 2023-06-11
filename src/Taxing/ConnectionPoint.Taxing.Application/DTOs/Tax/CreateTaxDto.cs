using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoint.Taxing.Application.DTOs.Tax
{
    public class CreateTaxDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public TaxTypeDto TaxType { get; set; } = TaxTypeDto.Included;
        public bool IsDefault { get; set; }
    }
}
