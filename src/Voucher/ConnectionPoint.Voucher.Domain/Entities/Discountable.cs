using ConnectionPoint.Core.Domain.Entities;

namespace ConnectionPoint.Voucher.Domain.Entities
{
    public class Discountable : FullAuditedEntityDto
    {
        public Guid DiscountableId { get; set; }
        public string DiscountableType { get; set; }
        public double NetPrice { get; set; }
        public List<Coupon> Coupons { get; set; } = new List<Coupon>();
    }
}
