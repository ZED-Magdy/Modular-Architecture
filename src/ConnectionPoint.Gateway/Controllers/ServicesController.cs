using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Service;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers;
[ApiController]
[Route("[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceAppService _serviceAppService;

    public ServicesController(IServiceAppService serviceAppService)
    {
        _serviceAppService = serviceAppService;
    }
    
    [HttpGet]
    public async Task<ActionResult<PaginatedResultDto<ServiceDto>>> Get([FromQuery]PaginationRequestDto paginationRequestDto, CancellationToken cancellationToken)
    {
        return await _serviceAppService.GetListAsync(paginationRequestDto, cancellationToken);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ServiceDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await _serviceAppService.GetAsync(id, cancellationToken);
        if (result is null )
        {
            return NotFound();
        }

        return Ok(result);
        
    }
    
    [HttpPost]
    public async Task<ActionResult<ServiceDto>> Post(CreateServiceDto serviceDto, CancellationToken cancellationToken)
    {
        return await _serviceAppService.CreateAsync(serviceDto, cancellationToken);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ServiceDto), 200)]
    [ProducesErrorResponseType(typeof(NotFoundResult))]
    public async Task<ActionResult<ServiceDto>> Put(Guid id, UpdateServiceDto serviceDto, CancellationToken cancellationToken)
    {
        var result = await _serviceAppService.UpdateAsync(id, serviceDto, cancellationToken);
        if (result is null )
        {
            return NotFound();
        }

        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _serviceAppService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}