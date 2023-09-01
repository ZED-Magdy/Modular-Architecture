using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.Unit;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IUnitAppService : ICrudAppService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto>
{
    
}