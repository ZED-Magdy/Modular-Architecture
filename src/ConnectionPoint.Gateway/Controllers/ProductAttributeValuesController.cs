using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttributeValue;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductAttributeValuesController : ControllerBase
{
    private readonly IProductAttributeValueAppService _productAttributeValueAppService;

    public ProductAttributeValuesController(IProductAttributeValueAppService productAttributeValueAppService)
    {
        _productAttributeValueAppService = productAttributeValueAppService;
    }
    
    [HttpGet]
    public async Task<PaginatedResultDto<ProductAttributeValueDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _productAttributeValueAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ProductAttributeValueDto?> Get(Guid id)
    {
        return await _productAttributeValueAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<ProductAttributeValueDto?> Create(CreateProductAttributeValueDto input)
    {
        return await _productAttributeValueAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ProductAttributeValueDto?> Update(Guid id, UpdateProductAttributeValueDto input)
    {
        return await _productAttributeValueAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _productAttributeValueAppService.DeleteAsync(id);
    }
}