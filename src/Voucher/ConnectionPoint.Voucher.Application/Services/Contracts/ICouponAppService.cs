using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;

namespace ConnectionPoint.Voucher.Application.Services.Contracts
{
    public interface ICouponAppService : ICrudAppService<Guid, CouponDto, CreateCouponDto, UpdateCouponDto>
    {
    }
}
