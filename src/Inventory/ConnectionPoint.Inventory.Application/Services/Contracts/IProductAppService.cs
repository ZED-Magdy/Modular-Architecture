using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Inventory.Application.Dtos.Product;

namespace ConnectionPoint.Inventory.Application.Services.Contracts;

public interface IProductAppService : ICrudAppService<Guid, ProductDto, CreateProductDto, UpdateProductDto>
{
}