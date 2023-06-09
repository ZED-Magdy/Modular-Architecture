using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ConnectionPoint.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly ICategoryAppService _categoryAppService;

    public ApiController(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpGet("/categories")]
    public async Task<PaginatedResultDto<CategoryDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _categoryAppService.GetListAsync(requestDto);
    }
}