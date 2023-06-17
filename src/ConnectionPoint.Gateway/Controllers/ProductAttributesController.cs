using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductAttributesController : ControllerBase
{
    private readonly IProductAttributeAppService _productAttributeAppService;

    public ProductAttributesController(IProductAttributeAppService productAttributeAppService)
    {
        _productAttributeAppService = productAttributeAppService;
    }
    
    [HttpGet]
    public async Task<PaginatedResultDto<ProductAttributeDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _productAttributeAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ProductAttributeDto?> Get(Guid id)
    {
        return await _productAttributeAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<ProductAttributeDto?> Create(CreateProductAttributeDto input)
    {
        return await _productAttributeAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ProductAttributeDto?> Update(Guid id, UpdateProductAttributeDto input)
    {
        return await _productAttributeAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _productAttributeAppService.DeleteAsync(id);
    }
}