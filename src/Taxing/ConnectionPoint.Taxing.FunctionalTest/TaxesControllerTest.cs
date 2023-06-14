using ConnectionPoint.Gateway.Controllers;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using Moq;

namespace ConnectionPoint.Taxing.FunctionalTest;

public class TaxesControllerTest
{
    [Fact]
    public async Task Get_Tax_by_id_Returns_the_Right_TaxDto()
    {
        //Arrange
        var taxId = Guid.NewGuid();
        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(cas => cas.GetAsync(taxId, default)).ReturnsAsync(new TaxDto
        {
            Id = taxId
        });
        
        //Act
        var controller = new TaxesController(taxAppService.Object);
        var response = await controller.Get(taxId);
        //Assert
        
        Assert.Equal(taxId, response?.Id);
    }
}