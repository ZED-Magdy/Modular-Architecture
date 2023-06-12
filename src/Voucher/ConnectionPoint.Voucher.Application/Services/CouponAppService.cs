using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using ConnectionPoint.Voucher.Domain.Entities;

namespace ConnectionPoint.Voucher.Application.Services
{
    public class CouponAppService : CrudAppService<Coupon, Guid, CouponDto, CreateCouponDto, UpdateCouponDto>,ICouponAppService
    {
        public CouponAppService(IRepository<Coupon> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
