using System.Linq.Expressions;
using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Inventory.Application.Services;

public class CategoryAppService : CrudAppService<Category, Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryAppService
{
    public CategoryAppService(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override Expression<Func<Category, bool>> GetFilterExpression(string search)
    {
        return c => 
            EF.Functions.Like(c.NameAr, $"%{search}%")
            || EF.Functions.Like(c.NameEn, $"%{search}%");
    }

    protected override Expression<Func<Category, object>> GetSortingFilter(string? inputSortBy)
    {
        return inputSortBy switch
        {
            "nameAr" => c => c.NameAr,
            "nameEn" => c => c.NameEn,
            "status" => c => c.Active,
            _ => c => c.CreatedOn
        };
    }
}