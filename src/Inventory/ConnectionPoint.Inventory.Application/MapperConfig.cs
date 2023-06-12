using AutoMapper;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Domain.Entities;

namespace ConnectionPoint.Inventory.Application;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        #region Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        #endregion

        #region Product
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(p => p.Categories, o => o.Ignore())
                .ForMember(p => p.TaxesIds, o => o.Ignore());
            CreateMap<UpdateProductDto, Product>()
                .ForMember(p => p.Categories, o => o.Ignore())
                .ForMember(p => p.TaxesIds, o => o.Ignore());
        #endregion
        
    }
}