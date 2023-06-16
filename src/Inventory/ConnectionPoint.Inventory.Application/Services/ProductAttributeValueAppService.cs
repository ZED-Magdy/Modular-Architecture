using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class ProductAttributeValueAppService : CrudAppService<ProductAttributeValue, Guid, ProductAttributeValueDto, CreateProductAttributeValueDto, UpdateProductAttributeValueDto>, IProductAttributeValueAppService
{
    public ProductAttributeValueAppService(IRepository<ProductAttributeValue> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    protected override Expression<Func<ProductAttributeValue, bool>> GetFilterExpression(string search)
    {
        return x => EF.Functions.Like(x.Name, $"%{search}%");
    }

    protected override Expression<Func<ProductAttributeValue, object>> GetSortingFilter(string? inputSortBy)
    {
        return inputSortBy switch
        {
            "id" => x => x.Id,
            "name" => x => x.Name,
            _ => x => x.CreatedOn
        };
    }
}