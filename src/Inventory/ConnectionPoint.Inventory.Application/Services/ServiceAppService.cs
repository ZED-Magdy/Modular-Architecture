using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Dtos.Service;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;

namespace ConnectionPoint.Inventory.Application.Services;

public class ServiceAppService : CrudAppService<Service, Guid, ServiceDto, CreateServiceDto, UpdateServiceDto>, IServiceAppService
{
    private readonly ITaxableAppService _taxableService;
    private readonly IRepository<Category> _categoryAppService;

    public ServiceAppService(IRepository<Service> repository, IMapper mapper, ITaxableAppService taxableService, IRepository<Category> categoryAppService) : base(repository, mapper)
    {
        _taxableService = taxableService;
        _categoryAppService = categoryAppService;
    }

    public override async Task<ServiceDto?> CreateAsync(CreateServiceDto input, CancellationToken cancellationToken = default)
    {
        var service = _mapper.Map<Service>(input);
        var categories = await _categoryAppService.GetListAsync(c => input.CategoriesIds.Contains(c.Id), cancellationToken);
        service.Categories = categories;
        //TODO: Calculate discount price
        await _repository.CreateAsync(service, cancellationToken);
        // Create taxable
        if (input.TaxesIds.Count > 0)
            await _taxableService.CreateAsync(new CreateTaxableDto
            {
                TaxableId = service.Id,
                TaxableType = nameof(Service),
                GrossPrice = service.GrossPrice,
                NetPrice = service.NetPrice,
                TaxesIds = input.TaxesIds
            }, cancellationToken);

        return _mapper.Map<ServiceDto>(service);
    }

    public override async Task<ServiceDto?> UpdateAsync(Guid id, UpdateServiceDto input,
        CancellationToken cancellationToken = default)
    {
        var service = await _repository.GetAsync(x => x.Id == id, cancellationToken);
        if (service == null)
        {
            return default;
        }

        service = _mapper.Map(input, service);
        var categories =
            await _categoryAppService.GetListAsync(c => input.CategoriesIds.Contains(c.Id), cancellationToken);
        service.Categories = categories;
        //TODO: Calculate discount price
        service = await _repository.UpdateAsync(service, cancellationToken);
        await _taxableService.UpdateAsync(service.Id, new UpdateTaxableDto
        {
            TaxableId = service.Id,
            TaxableType = nameof(Service),
            GrossPrice = service.GrossPrice,
            NetPrice = service.NetPrice,
            TaxesIds = input.TaxesIds
        }, cancellationToken);
        return _mapper.Map<ServiceDto>(service);
    }
}