using AutoMapper;
using ConnectionPoint.Inventory.Application.Dtos;
using ConnectionPoint.Inventory.Domain.Entities;

namespace ConnectionPoint.Inventory.Application;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}