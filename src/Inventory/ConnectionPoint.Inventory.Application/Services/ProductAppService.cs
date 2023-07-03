using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using Microsoft.EntityFrameworkCore;
namespace ConnectionPoint.Inventory.Application.Services;

public class ProductAppService : CrudAppService<Product, Guid, ProductDto, CreateProductDto, UpdateProductDto>, IProductAppService
{
    private readonly ITaxableAppService _taxableService;
    private readonly IRepository<Category> _categoryAppService;
    private readonly IRepository<ProductAttributeValue> _valuesRepository;
    private readonly IDiscountableAppService _discountableAppService;

    public ProductAppService(IRepository<Product> repository, IMapper mapper, ITaxableAppService taxableService,
        IRepository<Category> categoryAppService, IRepository<ProductAttributeValue> valuesRepository,
        IDiscountableAppService discountableAppService) : base(
        repository, mapper)
    {
        _taxableService = taxableService;
        _categoryAppService = categoryAppService;
        _valuesRepository = valuesRepository;
        _discountableAppService = discountableAppService;
    }

    public override async Task<ProductDto?> CreateAsync(CreateProductDto input, CancellationToken cancellationToken = default)
    {
        var product = _mapper.Map<Product>(input);
        var categories = await _categoryAppService.GetListAsync(c => input.CategoriesIds.Contains(c.Id), cancellationToken);
        product.Id = Guid.NewGuid();
        product.Categories = categories;
        if (input.ProductType == ProductTypeDto.Variant)
        {
            await CreateVariationsFor(product, input.Variations, cancellationToken);
        }

        var grossPrice = input.NetPrice;
        if (input.CouponId != null)
        {
            var discountable = await _discountableAppService.CreateAsync(new CreateDiscountableDto
            {
                CouponIds = new List<Guid>{ input.CouponId.Value },
                NetPrice = product.NetPrice,
                DiscountableId = product.Id,
                DiscountableType = nameof(Product)
            }, cancellationToken);
            grossPrice = discountable.NetPrice;
        }

        if (input.TaxesIds.Count > 0)
        {
            var taxable = await _taxableService.CreateAsync(new CreateTaxableDto
            {
                TaxableId = product.Id,
                TaxableType = nameof(Product),
                GrossPrice = grossPrice,
                NetPrice = product.NetPrice,
                TaxesIds = input.TaxesIds
            }, cancellationToken);
            grossPrice = taxable.GrossPrice;
        }
        product.GrossPrice = grossPrice;
        await _repository.CreateAsync(product, cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public override async Task<ProductDto?> UpdateAsync(Guid id, UpdateProductDto input, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetAsync(x => x.Id == id, cancellationToken);
        if (product == null)
        {
            return default;
        }
        product = _mapper.Map(input, product);
        if (input.ProductType == ProductTypeDto.Variant)
        {
            await CreateVariationsFor(product, input.Variations, cancellationToken);
        }
        var categories = await _categoryAppService.GetListAsync(c => input.CategoriesIds.Contains(c.Id), cancellationToken);
        product.Categories = categories;
        //TODO: Calculate discount price
        product = await _repository.UpdateAsync(product, cancellationToken);
        await _taxableService.UpdateAsync(product.Id, new UpdateTaxableDto
        {
            TaxableId = product.Id,
            TaxableType = nameof(Product),
            GrossPrice = product.GrossPrice,
            NetPrice = product.NetPrice,
            TaxesIds = input.TaxesIds
        }, cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }
    private async Task CreateVariationsFor(Product product, List<CreateVariationDto> inputVariations, CancellationToken cancellationToken)
    {
        var valuesIds = inputVariations.SelectMany(x => x.AttributeValues).Distinct().ToList();
        var values = await _valuesRepository.GetListAsync(x => valuesIds.Contains(x.Id), cancellationToken);
            product.Variations = new List<ProductVariation>();
        foreach (var variation in inputVariations)
        {
            product.Variations.Add(new ProductVariation
            {
                AttributeValues = values.Where(x => variation.AttributeValues.Contains(x.Id)).ToList(),
                Price = variation.Price,
                Stock = variation.Stock
            });
        }
    }
    protected override Expression<Func<Product, bool>> GetFilterExpression(string search)
    {
        return (p) =>
            EF.Functions.Like(p.NameAr, $"%{search}%")
            || EF.Functions.Like(p.NameEn, $"%{search}%")
            || EF.Functions.Like(p.Barcode, $"%{search}%");
    }
    protected override Expression<Func<Product, object>> GetSortingFilter(string? inputSortBy)
    {
        return inputSortBy switch
        {
            "nameAr" => c => c.NameAr,
            "nameEn" => c => c.NameEn,
            "barcode" => c => c.Barcode,
            "grossPrice" => c => c.GrossPrice,
            "netPrice" => c => c.NetPrice,
            "status" => c => c.Active,
            _ => c => c.CreatedOn
        };
    }

    protected override List<string>? GetIncludeList()
    {
        return new List<string>
        {
            "Categories",
            "Variations",
            "Variations.AttributeValues",
        };
    }
}