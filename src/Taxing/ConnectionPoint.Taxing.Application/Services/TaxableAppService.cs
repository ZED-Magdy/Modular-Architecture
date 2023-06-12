using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Taxing.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ConnectionPoint.Taxing.Application.Services
{
    public class TaxableAppService:CrudAppService<Taxable , Guid, TaxableDto, CreateTaxableDto, UpdateTaxableDto>, ITaxableAppService
    {
        private readonly IRepository<Taxable> repository;
        private readonly IMapper mapper;
        private readonly IRepository<Tax> taxRepository;
        public Expression<Func<Tax, bool>> predicate;
        public TaxableAppService(IRepository<Taxable> repository,IMapper mapper,IRepository<Tax> taxRepository):base (repository,mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.taxRepository = taxRepository;
        }
        public override async Task<TaxableDto?> CreateAsync(CreateTaxableDto input, CancellationToken cancellationToken = default)
        {
            predicate = (e) => input.TaxesIds.Contains(e.Id); 
            List<Tax> taxes = await taxRepository.GetListAsync(predicate);
            Taxable taxable = new Taxable(input.TaxableId, input.TaxableType, input.GrossPrice, taxes);
            var entity = await repository.CreateAsync(taxable, cancellationToken);
            TaxableDto result = mapper.Map<Taxable,TaxableDto>(entity); 
            return result;
        }
        public override async Task<TaxableDto?> UpdateAsync(Guid id, UpdateTaxableDto input, CancellationToken cancellationToken = default)
        {
            var taxEntity = await repository.GetByIdAsync(id);
            if (taxEntity == null)
            {
                return default;
            }
            taxEntity = mapper.Map<UpdateTaxableDto, Taxable>(input);
            predicate = (e) => input.TaxesIds.Contains(e.Id);
            List<Tax> taxes = await taxRepository.GetListAsync(predicate);
            Taxable taxable = new Taxable(input.TaxableId, input.TaxableType, input.GrossPrice, taxes);
            var entity = await repository.UpdateAsync(taxable, cancellationToken);
            TaxableDto result = mapper.Map<Taxable, TaxableDto>(entity);
            return result;
        }
    }
}
