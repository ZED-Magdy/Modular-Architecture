using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.Deal;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class DealAppService : CrudAppService<Deal, Guid, DealDto, CreateDealDto, UpdateDealDto>, IDealAppService
{
    private readonly ITaxableAppService _taxableAppService;
    private readonly IRepository<Service> _servicesRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly IDiscountableAppService _discountableService;

    public DealAppService(IRepository<Deal> repository, IMapper mapper, ITaxableAppService taxableAppService, IRepository<Service> servicesRepository, IRepository<Product> productRepository, IDiscountableAppService discountableService) : base(repository, mapper)
    {
        _taxableAppService = taxableAppService;
        _servicesRepository = servicesRepository;
        _productRepository = productRepository;
        _discountableService = discountableService;
    }

    public override async Task<DealDto?> CreateAsync(CreateDealDto input, CancellationToken cancellationToken = default)
    {
        var deal = _mapper.Map<Deal>(input);
        deal.Id = Guid.NewGuid();
        await updateDealRelations(input.ProductsIds, input.ServicesIds, input.DealsIds, cancellationToken, deal);
        //TODO: Calculate discount price
        await _discountableService.CreateAsync(new CreateDiscountableDto
        {
            DiscountableId = deal.Id,
            DiscountableType = nameof(Deal),
            NetPrice = deal.NetPrice,
            CouponIds = new List<Guid>()
        });
        // Create taxable
        if (input.TaxesIds.Count > 0)
            await _taxableAppService.CreateAsync(new CreateTaxableDto
            {
                TaxableId = deal.Id,
                TaxableType = nameof(Deal),
                GrossPrice = deal.GrossPrice,
                NetPrice = deal.NetPrice,
                TaxesIds = input.TaxesIds
            }, cancellationToken);
        await _repository.CreateAsync(deal, cancellationToken);
        return _mapper.Map<DealDto>(deal);
    }

    public override async Task<DealDto?> UpdateAsync(Guid id, UpdateDealDto input, CancellationToken cancellationToken = default)
    {
        var deal = await _repository.GetAsync(x => x.Id == id, cancellationToken);
        if (deal == null)
        {
            return default;
        }
        deal = _mapper.Map(input, deal);
        await updateDealRelations(input.ProductsIds, input.ServicesIds, input.DealsIds, cancellationToken, deal);
        //TODO: Calculate discount price
        deal = await _repository.UpdateAsync(deal, cancellationToken);
        await _taxableAppService.UpdateAsync(deal.Id, new UpdateTaxableDto
        {
            TaxableId = deal.Id,
            TaxableType = nameof(Deal),
            GrossPrice = deal.GrossPrice,
            NetPrice = deal.NetPrice,
            TaxesIds = input.TaxesIds
        }, cancellationToken);
        return _mapper.Map<DealDto>(deal);
    }

    private async Task updateDealRelations(IList<Guid> productsIds, IList<Guid> servicesIds, IList<Guid> dealsIds,
        CancellationToken cancellationToken, Deal deal)
    {
        if (servicesIds.Count > 0)
        {
            var services = await _servicesRepository.GetListAsync(x => servicesIds.Contains(x.Id), cancellationToken);
            deal.Services = services;
        }
        else
        {
            deal.Services = new List<Service>();
        }

        if (productsIds.Count > 0)
        {
            var products = await _productRepository.GetListAsync(x => productsIds.Contains(x.Id), cancellationToken);
            deal.Products = products;
        }
        else
        {
            deal.Products = new List<Product>();
        }

        if (dealsIds.Count > 0)
        {
            var deals = await _repository.GetListAsync(x => dealsIds.Contains(x.Id), cancellationToken);
            deal.Deals = deals;
        }
        else
        {
            deal.Deals = new List<Deal>();
        }
    }

    protected override Expression<Func<Deal, bool>> GetFilterExpression(string search)
    {
        return (p) =>
            EF.Functions.Like(p.NameAr, $"%{search}%")
            || EF.Functions.Like(p.NameEn, $"%{search}%");
    }
    protected override Expression<Func<Deal, object>> GetSortingFilter(string? inputSortBy)
    {
        return inputSortBy switch
        {
            "nameAr" => c => c.NameAr,
            "nameEn" => c => c.NameEn,
            "grossPrice" => c => c.GrossPrice,
            "netPrice" => c => c.NetPrice,
            "status" => c => c.Active,
            _ => c => c.CreatedOn
        };
    }
}