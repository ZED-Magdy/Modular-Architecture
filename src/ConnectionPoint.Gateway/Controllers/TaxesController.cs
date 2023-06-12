using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxAppService _taxAppService;

        public TaxesController(ITaxAppService taxAppService)
        {
            _taxAppService = taxAppService;
        }
        [HttpGet]
        public async Task<PaginatedResultDto<TaxDto>> Get([FromQuery] PaginationRequestDto requestDto)
        {
            return await _taxAppService.GetListAsync(requestDto);
        }
        [HttpGet("id:guid")]
        public async Task<TaxDto?> Get(Guid id)
        {
            return await _taxAppService.GetAsync(id);
        }
        [HttpPost]
        public async Task<TaxDto?> Create(CreateTaxDto taxDto)
        {
            return await _taxAppService.CreateAsync(taxDto);
        }
        [HttpPut]
        public async Task<TaxDto?> Update(Guid id ,UpdateTaxDto taxDto)
        {
            return await _taxAppService.UpdateAsync(id,taxDto);
        }
        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await _taxAppService.DeleteAsync(id);
        }
    }
}
