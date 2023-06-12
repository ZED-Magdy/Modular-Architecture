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
        public TaxableAppService(IRepository<Taxable> repository,IMapper mapper,IRepository<Tax> taxRepository):base (repository,mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.taxRepository = taxRepository;
        }
        public override async Task<TaxableDto?> CreateAsync(CreateTaxableDto input, CancellationToken cancellationToken = default)
        {
            Expression<Func<Tax, bool>> predicate = (e) => input.TaxesIds.Contains(e.Id); 
            List<Tax> taxes = await taxRepository.GetListAsync(predicate);
            Taxable taxable = new Taxable();
            taxable.Create(input.TaxableId, input.TaxableType, input.GrossPrice, taxes);
            var entity = await repository.CreateAsync(taxable, cancellationToken);
            TaxableDto result = mapper.Map<Taxable,TaxableDto>(entity); 
            return result;
        }
        public override async Task<TaxableDto?> UpdateAsync(Guid id, UpdateTaxableDto input, CancellationToken cancellationToken = default)
        {
            var taxEntity = await repository.GetByIdAsync(id); // ef track the element, when i call update method is that make another tracking ?
            if (taxEntity == null)
            {
                return default;
            }
            Expression<Func<Tax, bool>> predicate = (e) => input.TaxesIds.Contains(e.Id);
            List<Tax> taxes = await taxRepository.GetListAsync(predicate);
            taxEntity.Create(input.TaxableId, input.TaxableType, input.GrossPrice, taxes);
            var entity = await repository.UpdateAsync(taxEntity, cancellationToken);
            TaxableDto result = mapper.Map<Taxable, TaxableDto>(entity);
            return result;
        }
    }
}
