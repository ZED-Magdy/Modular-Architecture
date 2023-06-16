using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class ProductAttributeAppService : CrudAppService<ProductAttribute, Guid, ProductAttributeDto, CreateProductAttributeDto, UpdateProductAttributeDto>
{
    public ProductAttributeAppService(IRepository<ProductAttribute> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    protected override Expression<Func<ProductAttribute, bool>> GetFilterExpression(string search)
    {
        return x => EF.Functions.Like(x.Name, $"%{search}%");
    }

    protected override Expression<Func<ProductAttribute, object>> GetSortingFilter(string? inputSortBy)
    {
        return inputSortBy switch
        {
            "id" => x => x.Id,
            "name" => x => x.Name,
            _ => x => x.CreatedOn
        };
    }
}