using AutoMapper;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Application.Dtos.Category;
using ConnectionPoint.Inventory.Application.Dtos.Deal;
using ConnectionPoint.Inventory.Application.Dtos.Product;
using ConnectionPoint.Inventory.Application.Dtos.ProductAttribute;
using ConnectionPoint.Inventory.Application.Dtos.Service;
using ConnectionPoint.Inventory.Application.Dtos.Unit;
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
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        #endregion
        
        #region Service
            CreateMap<Service, ServiceDto>();
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();

            #endregion

        #region Deal
            CreateMap<Deal, DealDto>();
            CreateMap<UpdateDealDto, Deal>();
            CreateMap<CreateDealDto, Deal>();
        #endregion
        
        #region Unit
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<UpdateUnitDto, Unit>();
        #endregion
        
        #region ProductAttribute
            CreateMap<ProductAttribute, ProductAttributeDto>();
            CreateMap<CreateProductAttributeDto, ProductAttribute>();
            CreateMap<UpdateProductAttributeDto, ProductAttribute>();
        #endregion
    }
}