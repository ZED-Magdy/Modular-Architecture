using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Taxing.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoint.Taxing.Domain.Entities
{
    public class Tax : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public TaxType TaxType { get; set; } = TaxType.Included;
        public bool IsDefault { get; set; }
    }
}
