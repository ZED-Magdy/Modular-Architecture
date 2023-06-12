using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Taxing.Application.DTOs.Tax;

namespace ConnectionPoint.Taxing.Application.Services.Contracts
{
    public interface ITaxAppService:ICrudAppService<Guid,TaxDto , CreateTaxDto, UpdateTaxDto>
    {
    }
}
