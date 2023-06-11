using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Taxing.Domain.Entities;

namespace ConnectionPoint.Taxing.Application.Services
{
    public class TaxableAppService:CrudAppService<Taxable , Guid, TaxableDto, CreateTaxableDto, UpdateTaxableDto>, ITaxableAppService
    {
        public TaxableAppService(IRepository<Taxable> repository,IMapper mapper):base (repository,mapper)
        {
        }
    }
}
