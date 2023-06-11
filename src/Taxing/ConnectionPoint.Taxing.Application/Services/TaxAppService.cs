using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Taxing.Domain.Entities;

namespace ConnectionPoint.Taxing.Application.Services
{
    public class TaxAppService:CrudAppService<Tax,Guid,TaxDto,CreateTaxDto,UpdateTaxDto>,ITaxAppService
    {
        public TaxAppService(IRepository<Tax> repository , IMapper mapper) :base(repository,mapper)
        {
        }
    }
}
