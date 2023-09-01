using AutoMapper;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;
using ConnectionPoint.Voucher.Domain.Entities;

namespace ConnectionPoint.Voucher.Application
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region Coupon
            CreateMap<Coupon, CouponDto>();
            CreateMap<CreateCouponDto, Coupon>();
            CreateMap<UpdateCouponDto, Coupon>();
            #endregion

            #region Discountable
            CreateMap<Discountable, DiscountableDto>();
            CreateMap<CreateDiscountableDto, Discountable>();
            CreateMap<UpdateDiscountableDto, Discountable>();
            #endregion
        }
    }
}