using ConnectionPoint.Voucher.Application.Dtos.Coupon;

namespace ConnectionPoint.Voucher.Application.Dtos.Discountable
{
    public class UpdateDiscountableDto
    {
        public Guid DiscountableId { get; set; }
        public string DiscountableType { get; set; }
        public double NetPrice { get; set; }
        public List<Guid> CouponIds { get; set; } = new List<Guid>();
        public List<CouponDto> Coupons { get; set; } = new List<CouponDto>();
    }
}
