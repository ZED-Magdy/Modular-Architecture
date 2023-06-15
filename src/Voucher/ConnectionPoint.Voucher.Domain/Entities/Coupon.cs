using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Voucher.Domain.Entities.Enums;

namespace ConnectionPoint.Voucher.Domain.Entities
{
    public class Coupon: FullAuditedEntity
    {
        public string Code { get; set; }
        public Guid? CustomerId { get; set; }
        public decimal Discount { get; set; }
        public CouponDiscountType DiscountType { get; set; } = CouponDiscountType.Percentage;
        public DateTime? ExpirationDate { get; set; }
        public int UseLimit { get; set; } = 1;
    }
}
