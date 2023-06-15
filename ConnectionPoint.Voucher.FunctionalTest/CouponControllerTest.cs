
using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Gateway.Controllers;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Voucher.Application.Dtos.Coupon;
using ConnectionPoint.Voucher.Application.Dtos.Enums;
using ConnectionPoint.Voucher.Application.Services.Contracts;

namespace ConnectionPoint.Voucher.FunctionalTest
{
    public class CouponControllerTest
    {
        [Fact]
        public async Task Get_Coupon_By_Id_Return_CouponDTO()
        {
            //Arrange

            var couponId = Guid.NewGuid();
            var couponAppService = new Mock<ICouponAppService>();
            couponAppService.Setup(cas => cas.GetAsync(couponId, default)).ReturnsAsync(new CouponDto()
            {
                Id = couponId,
            });
            //Act
            var controller = new CouponsController(couponAppService.Object);
            var result = await controller.Get(couponId);
            //Assert
            Assert.Equal(couponId, result?.Id);
        }
        [Fact]
        public async Task Get_List_Coupon_Returns_the_Right_List_CouponDto()
        {
            //Arrange
            var paginationDto = new PaginationRequestDto
            {
                Page = 1,
                PerPage = 10,
                SortBy = "id",
                SortDirection = "asc",
            };
            var couponAppService = new Mock<ICouponAppService>();
            var expected = new List<CouponDto>(){
            new CouponDto
            {
             Id = new Guid(),
             Discount = 1,
             Code ="Rfesf32@w",
             ExpirationDate = DateTime.UtcNow.AddDays(7),
             DiscountType = CouponDiscountTypeDto.Amount,
             CustomerId = new Guid(),
             UseLimit = 10,
            },
            new CouponDto
            {
             Id = new Guid(),
             Discount = 1,
             Code ="Rfessssf32@w",
             ExpirationDate = DateTime.UtcNow.AddDays(7),
             DiscountType = CouponDiscountTypeDto.Percentage,
             CustomerId = new Guid(),
             UseLimit = 15,
            },
           };
            var paginatedResultDto = new PaginatedResultDto<CouponDto>(paginationDto.Page, paginationDto.PerPage, 2, 2, expected);
            couponAppService.Setup(tas => tas.GetListAsync(paginationDto, default)).ReturnsAsync(paginatedResultDto);
            //Act
            var controller = new CouponsController(couponAppService.Object);
            var response = await controller.Get(paginationDto);
            //Assert
            Assert.Equal(paginatedResultDto, response);
        }
        [Fact]
        public async Task Create_Coupon_Returns_CouponDto()
        {
            //Arrange
            var Coupon = new CreateCouponDto()
            {
                Discount = 1,
                Code = "Rfesf32@w",
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                DiscountType = CouponDiscountTypeDto.Amount,
                CustomerId = new Guid(),
                UseLimit = 10,
            };
            CouponDto CouponDto = new CouponDto()
            {
                Discount = 1,
                Code = "Rfesf32@w",
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                DiscountType = CouponDiscountTypeDto.Amount,
                CustomerId = new Guid(),
                UseLimit = 10,
            };
            var couponAppService = new Mock<ICouponAppService>();
            couponAppService.Setup(tas => tas.CreateAsync(Coupon, default)).ReturnsAsync(CouponDto);
            //Act
            var controller = new CouponsController(couponAppService.Object);
            var response = await controller.Create(Coupon);
            //Assert

            Assert.Equal<CouponDto>(CouponDto, response);
            couponAppService.Verify(tas => tas.CreateAsync(Coupon, default), Times.Once);
        }
        [Fact]
        public async Task Update_Tax_Returns_CouponDto()
        {
            //Arrange
            var couponId = new Guid();
            var coupon = new UpdateCouponDto()
            {
                Discount = 1,
                Code = "Rfesf32@w",
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                DiscountType = CouponDiscountTypeDto.Amount,
                CustomerId = new Guid(),
                UseLimit = 10,
            };
            CouponDto CouponDto = new CouponDto()
            {
                Discount = coupon.Discount,
                Code = coupon.Code,
                ExpirationDate = coupon.ExpirationDate,
                DiscountType = coupon.DiscountType,
                CustomerId = coupon.CustomerId,
                UseLimit = coupon.UseLimit,
                Id = couponId,
            };
            var couponAppService = new Mock<ICouponAppService>();
            couponAppService.Setup(tas => tas.UpdateAsync(couponId, coupon, default)).ReturnsAsync(CouponDto);
            //Act
            var controller = new CouponsController(couponAppService.Object);
            var response = await controller.Update(couponId, coupon);
            //Assert
            Assert.Equal<CouponDto>(CouponDto, response);
            couponAppService.Verify(tas => tas.UpdateAsync(couponId, coupon, default), Times.Once);
        }
        [Fact]
        public async Task Delete_TCoupon_Returns_CouponDto()
        {
            //Arrange
            var couponId = Guid.NewGuid();
            var couponAppService = new Mock<ICouponAppService>();
            couponAppService.Setup(tas => tas.DeleteAsync(couponId, default));
            //Act
            var controller = new CouponsController(couponAppService.Object);
            await controller.Delete(couponId);
            //Assert
            couponAppService.Verify(tas => tas.DeleteAsync(couponId, default), Times.Once);
        }
    }
}