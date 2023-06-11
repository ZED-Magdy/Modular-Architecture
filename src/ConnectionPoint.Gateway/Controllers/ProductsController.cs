using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductAppService _productAppService;

    public ProductsController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }
    
    [HttpGet]
    public async Task<PaginatedResultDto<ProductDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _productAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ProductDto?> Get(Guid id)
    {
        return await _productAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<ProductDto?> Create(CreateProductDto input)
    {
        return await _productAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ProductDto?> Update(Guid id, UpdateProductDto input)
    {
        return await _productAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _productAppService.DeleteAsync(id);
    }
}