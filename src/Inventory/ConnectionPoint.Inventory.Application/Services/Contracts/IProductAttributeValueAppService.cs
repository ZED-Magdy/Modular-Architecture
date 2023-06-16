using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IProductAttributeValueAppService : ICrudAppService<Guid, ProductAttributeValueDto, CreateProductAttributeValueDto, UpdateProductAttributeValueDto>
{
    
}