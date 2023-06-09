using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Domain.Entities;

namespace ConnectionPoint.Inventory.Application.Services;

public class CategoryAppService : CrudAppService<Category, Guid, CategoryDto>, ICategoryAppService
{
    public CategoryAppService(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
}