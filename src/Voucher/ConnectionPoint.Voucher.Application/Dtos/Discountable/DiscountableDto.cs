using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;

namespace ConnectionPoint.Voucher.Application.Dtos.Discountable
{
    public class DiscountableDto : FullAuditedDto
    {
        public Guid DiscountableId { get; set; }
        public string TDiscountableType { get; set; }
        public double NetPrice { get; set; }
        public List<CouponDto> Coupons { get; set; } = new List<CouponDto>();
    }
}
