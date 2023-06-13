using AutoMapper;
using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using ConnectionPoint.Voucher.Domain.Entities;

namespace ConnectionPoint.Voucher.Application.Services
{
    public class DiscountableAppService:CrudAppService<Discountable,Guid,DiscountableDto,CreateDiscountableDto,UpdateDiscountableDto>,IDiscountableAppService
    {
        public DiscountableAppService(IRepository<Discountable> repository , IMapper mapper):base(repository,mapper)
        {
        }
    }
}
