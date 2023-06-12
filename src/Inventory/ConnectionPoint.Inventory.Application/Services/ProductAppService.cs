using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class ProductAppService : CrudAppService<Product, Guid, ProductDto, CreateProductDto, UpdateProductDto>, IProductAppService
{
    public ProductAppService(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override Expression<Func<Product, bool>> GetFilterExpression(string search)
    {
        return (p) =>
            EF.Functions.Like(p.NameAr, $"%{search}%")
            || EF.Functions.Like(p.NameEn, $"%{search}%")
            || EF.Functions.Like(p.Barcode, $"%{search}%");
    }
}