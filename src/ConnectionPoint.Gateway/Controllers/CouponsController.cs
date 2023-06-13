using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionPoint.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponAppService _couponAppService;

        public CouponsController(ICouponAppService couponAppService)
        {
            _couponAppService = couponAppService;
        }
        [HttpGet]
        public async Task<PaginatedResultDto<CouponDto>> Get([FromQuery] PaginationRequestDto requestDto)
        {
            return await _couponAppService.GetListAsync(requestDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<CouponDto?> Get(Guid id)
        {
            return await _couponAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<CouponDto?> Create(CreateCouponDto input)
        {
            return await _couponAppService.CreateAsync(input);
        }

        [HttpPut("{id:guid}")]
        public async Task<CouponDto?> Update(Guid id, UpdateCouponDto input)
        {
            return await _couponAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await _couponAppService.DeleteAsync(id);
        }
    }
}
