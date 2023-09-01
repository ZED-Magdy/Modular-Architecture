using ConnectionPoint.Core.Application.Services;
using ConnectionPoint.Voucher.Application.Dtos.Discountable;

namespace ConnectionPoint.Voucher.Application.Services.Contracts
{
    public interface IDiscountableAppService:ICrudAppService<Guid,DiscountableDto,CreateDiscountableDto,UpdateDiscountableDto>
    {
    }
}
