using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.Service;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IServiceAppService : ICrudAppService<Guid, ServiceDto, CreateServiceDto, UpdateServiceDto>
{
    
}