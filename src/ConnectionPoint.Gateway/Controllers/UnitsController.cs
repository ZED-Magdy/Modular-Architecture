using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Unit;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : ControllerBase
{
    private readonly IUnitAppService _unitAppService;

    public UnitsController(IUnitAppService unitAppService)
    {
        _unitAppService = unitAppService;
    }
    
    [HttpGet]
    public async Task<PaginatedResultDto<UnitDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _unitAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<UnitDto?> Get(Guid id)
    {
        return await _unitAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<UnitDto?> Create(CreateUnitDto input)
    {
        return await _unitAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<UnitDto?> Update(Guid id, UpdateUnitDto input)
    {
        return await _unitAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _unitAppService.DeleteAsync(id);
    }
}