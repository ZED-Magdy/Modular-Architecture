using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.Deal;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IDealAppService : ICrudAppService<Guid, DealDto, CreateDealDto, UpdateDealDto>
{
    
}