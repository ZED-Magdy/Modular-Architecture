using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using ConnectionPoint.Voucher.Domain.Entities;
using ConnectionPoint.Voucher.Domain.Entities.Enums;

namespace ConnectionPoint.Voucher.Application.Services
{
    public class DiscountableAppService:CrudAppService<Discountable,Guid,DiscountableDto,CreateDiscountableDto,UpdateDiscountableDto>,IDiscountableAppService
    {
        private readonly IRepository<Coupon> _couponRepo;

        public DiscountableAppService(IRepository<Discountable> repository , IMapper mapper, IRepository<Coupon> couponRepo):base(repository,mapper)
        {
            _couponRepo = couponRepo;
        }

        public override async Task<DiscountableDto?> CreateAsync(CreateDiscountableDto input, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Discountable>(input);
            var coupons = await _couponRepo.GetListAsync(c => input.CouponIds.Contains(c.Id), cancellationToken);
            decimal totalPrice = input.NetPrice;
            foreach (var coupon in coupons)
            {
                if (totalPrice > 0)
                {
                    if(coupon.DiscountType == CouponDiscountType.Percentage)
                        totalPrice -= totalPrice * coupon.Discount / 100;
                    else
                        if(coupon.Discount >= totalPrice)
                            totalPrice = 0;
                        else
                            totalPrice -= coupon.Discount;
                }
            }
            entity.NetPrice = (double)totalPrice;
            entity = await _repository.CreateAsync(entity, cancellationToken);
            return _mapper.Map<DiscountableDto>(entity);
        }
    }
}
