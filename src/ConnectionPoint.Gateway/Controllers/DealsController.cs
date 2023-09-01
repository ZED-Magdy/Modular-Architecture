using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Deal;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;
[ApiController]
[Route("[controller]")]
public class DealsController : ControllerBase
{
    private readonly IDealAppService _dealAppService;

    public DealsController(IDealAppService dealAppService)
    {
        _dealAppService = dealAppService;
    }
    
    [HttpGet]
    public async Task<PaginatedResultDto<DealDto>> Get([FromQuery]PaginationRequestDto requestDto)
    {
        return await _dealAppService.GetListAsync(requestDto);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<DealDto?> Get(Guid id)
    {
        return await _dealAppService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task<DealDto?> Create(CreateDealDto input)
    {
        return await _dealAppService.CreateAsync(input);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<DealDto?> Update(Guid id, UpdateDealDto input)
    {
        return await _dealAppService.UpdateAsync(id, input);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await _dealAppService.DeleteAsync(id);
    }
}