using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface ICategoryAppService : ICrudAppService<Guid, CategoryDto>
{
}