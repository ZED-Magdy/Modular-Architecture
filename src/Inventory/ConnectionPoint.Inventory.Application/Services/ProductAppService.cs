using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class ProductAppService : CrudAppService<Product, Guid, ProductDto, CreateProductDto, UpdateProductDto>, IProductAppService
{
    private readonly ITaxableAppService _taxableService;
    private readonly IRepository<Category> _categoryAppService;

    public ProductAppService(IRepository<Product> repository, IMapper mapper, ITaxableAppService taxableService, IRepository<Category> categoryAppService) : base(repository, mapper)
    {
        _taxableService = taxableService;
        _categoryAppService = categoryAppService;
    }

    public override async Task<ProductDto?> CreateAsync(CreateProductDto input, CancellationToken cancellationToken = default)
    {
        var product = _mapper.Map<Product>(input);
        var categories = await _categoryAppService.GetListAsync(c => input.CategoriesIds.Contains(c.Id), cancellationToken);
        product.Categories = categories;
        //TODO: Calculate discount price
        await _repository.CreateAsync(product, cancellationToken);
        // Create taxable
        if (input.TaxesIds.Count > 0)
            await _taxableService.CreateAsync(new CreateTaxableDto
            {
                TaxableId = product.Id,
                TaxableType = nameof(Product),
                GrossPrice = product.GrossPrice,
                NetPrice = product.NetPrice,
                TaxesIds = input.TaxesIds
            }, cancellationToken);

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

    protected override Expression<Func<Product, bool>> GetFilterExpression(string search)
    {
        return (p) =>
            EF.Functions.Like(p.NameAr, $"%{search}%")
            || EF.Functions.Like(p.NameEn, $"%{search}%")
            || EF.Functions.Like(p.Barcode, $"%{search}%");
    }
}