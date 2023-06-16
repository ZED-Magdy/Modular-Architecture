using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IProductAttributeAppService : ICrudAppService<Guid, ProductAttributeDto, CreateProductAttributeDto, UpdateProductAttributeDto>
{
    
}