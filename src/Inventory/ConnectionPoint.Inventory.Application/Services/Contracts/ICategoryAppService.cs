using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface ICategoryAppService : ICrudAppService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
}