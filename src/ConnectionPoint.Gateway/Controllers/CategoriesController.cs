using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ConnectionPoint.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryAppService _categoryAppService;

    public CategoriesController(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpGet]
    public async Task<PaginatedResultDto<CategoryDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _categoryAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<CategoryDto?> Get(Guid id)
    {
        return await _categoryAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<CategoryDto?> Create(CreateCategoryDto input)
    {
        return await _categoryAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<CategoryDto?> Update(Guid id, UpdateCategoryDto input)
    {
        return await _categoryAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _categoryAppService.DeleteAsync(id);
    }
}