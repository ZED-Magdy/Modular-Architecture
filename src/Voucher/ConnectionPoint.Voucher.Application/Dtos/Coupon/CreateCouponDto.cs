using ConnectionPoint.Voucher.Application.Dtos.Enums;

namespace ConnectionPoint.Voucher.Application.Dtos.Coupon
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public Guid? CustomerId { get; set; }
        public decimal Discount { get; set; }
        public CouponDiscountTypeDto DiscountType { get; set; } = CouponDiscountTypeDto.Percentage;
        public DateTime? ExpirationDate { get; set; }
        public int UseLimit { get; set; } = 1;
    }
}
