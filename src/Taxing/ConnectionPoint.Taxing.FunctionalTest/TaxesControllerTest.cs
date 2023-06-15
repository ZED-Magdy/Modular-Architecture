using AutoMapper;
using ConnectionPoint.Core.Application.Dtos;
using ConnectionPoint.Gateway.Controllers;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Taxing.Domain.Entities;
using Moq;
using System.Globalization;

namespace ConnectionPoint.Taxing.FunctionalTest;

public class TaxesControllerTest
{
    [Fact]
    public async Task Get_Tax_by_id_Returns_the_Right_TaxDto()
    {
        //Arrange
        var taxId = Guid.NewGuid();
        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(tas => tas.GetAsync(taxId, default)).ReturnsAsync(new TaxDto
        {
            Id = taxId
        });
        //Act
        var controller = new TaxesController(taxAppService.Object);
        var response = await controller.Get(taxId);
        //Assert

        Assert.Equal(taxId, response?.Id);
    }
    [Fact]
    public async Task Get_List_Taxs_Returns_the_Right_List_TaxsDto()
    {
        //Arrange
        var paginationDto = new PaginationRequestDto
        {
            Page = 1,
            PerPage = 10,
            SortBy = "id",
            SortDirection = "asc",
        };
        var taxAppService = new Mock<ITaxAppService>();
        var expected = new List<TaxDto>(){
            new TaxDto 
            {
             Id = new Guid(),
             Name = "tax1",
             Rate = 10,
             TaxType = TaxTypeDto.Excluded,
            },
            new TaxDto 
            {
             Id = new Guid(),
             Name = "tax2",
             Rate = 14,
             TaxType = TaxTypeDto.Included,
            },
        };

        var paginatedResultDto = new PaginatedResultDto<TaxDto>(paginationDto.Page, paginationDto.PerPage, 2, 2, expected);
        taxAppService.Setup(tas => tas.GetListAsync(paginationDto, default)).ReturnsAsync(paginatedResultDto);
        //Act
        var controller = new TaxesController(taxAppService.Object);
        var response = await controller.Get(paginationDto);
        //Assert

        Assert.Equal(paginatedResultDto, response);
    }
    [Fact]
    public async Task Get_TaxList_Returns_PaginatedResultDto()
    {
        // Arrange
        var taxList = new List<TaxDto>
    {
        new TaxDto { Id = Guid.NewGuid() },
        new TaxDto { Id = Guid.NewGuid() },
        new TaxDto { Id = Guid.NewGuid() }
    };

        var paginationRequest = new PaginationRequestDto
        {
            Page = 1,
            PerPage = 10, 
            SortBy = "Id",
            SortDirection = "asc"
        };

        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(tas => tas.GetListAsync(paginationRequest, default))
            .ReturnsAsync(new PaginatedResultDto<TaxDto>(
                paginationRequest.Page,
                paginationRequest.PerPage,
                taxList.Count,
                (int)Math.Ceiling((double)taxList.Count / paginationRequest.PerPage),
                taxList));
        var controller = new TaxesController(taxAppService.Object);
        // Act
        var response = await controller.Get(paginationRequest);
        // Assert
        Assert.Equal(taxList.Count, response.Total);
        Assert.Equal(taxList.Count, response.Data.Count);
    }
    [Fact]
    public async Task Create_Tax_Returns_TaxDto()
    {
        //Arrange
        var tax = new CreateTaxDto()
        {
            Description = "Description",
            Name = "Name",
            Rate = 100,
            TaxType = TaxTypeDto.Excluded,
            IsDefault = true,
        };
        TaxDto taxDto = new TaxDto()
        {
            Description = "Description",
            Name = "Name",
            Rate = 100,
            TaxType = TaxTypeDto.Excluded,
            IsDefault = true,
            Id = new Guid(),
        };
        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(tas => tas.CreateAsync(tax, default)).ReturnsAsync(taxDto);
        //Act
        var controller = new TaxesController(taxAppService.Object);
        var response = await controller.Create(tax);
        //Assert

        Assert.Equal<TaxDto>(taxDto, response);
        taxAppService.Verify(tas => tas.CreateAsync(tax, default), Times.Once);
    }
    [Fact]
    public async Task Update_Tax_Returns_TaxDto()
    {
        //Arrange
        var taxId = new Guid();
        var tax = new UpdateTaxDto()
        {
            Description = "Description",
            Name = "Name",
            Rate = 100,
            TaxType = TaxTypeDto.Excluded,
            IsDefault = true,
        };
        TaxDto taxDto = new TaxDto()
        {
            Description = tax.Description,
            Name = tax.Name,
            Rate = tax.Rate,
            TaxType = tax.TaxType,
            IsDefault = tax.IsDefault,
            Id = taxId,
        };
        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(tas => tas.UpdateAsync(taxId, tax, default)).ReturnsAsync(taxDto);
        //Act
        var controller = new TaxesController(taxAppService.Object);
        var response = await controller.Update(taxId, tax);
        //Assert

        Assert.Equal<TaxDto>(taxDto, response);
        taxAppService.Verify(tas => tas.UpdateAsync(taxId, tax, default), Times.Once);
    }
    [Fact]
    public async Task Delete_Tax_Returns_TaxDto()
    {
        //Arrange
        var taxId = Guid.NewGuid();
        var taxAppService = new Mock<ITaxAppService>();
        taxAppService.Setup(tas => tas.DeleteAsync(taxId ,default));
        //Act
        var controller = new TaxesController(taxAppService.Object);
        await controller.Delete(taxId);

        //Assert
        taxAppService.Verify(tas => tas.DeleteAsync(taxId, default), Times.Once);
    }
}