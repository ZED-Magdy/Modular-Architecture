using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;

namespace ConnectionPoint.Taxing.Application.Services.Contracts
{
    public interface ITaxableAppService:ICrudAppService<Guid,TaxableDto,CreateTaxableDto,UpdateTaxableDto>
    {
    }
}
