using AutoMapper;
using ConnectionPoint.Taxing.Application.DTOs.Tax;
using ConnectionPoint.Taxing.Application.DTOs.Taxable;
using ConnectionPoint.Taxing.Domain.Entities;

namespace ConnectionPoint.Taxing.Application
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region Tax
            CreateMap<Tax, TaxDto>();
            CreateMap<CreateTaxDto, Tax>();
            CreateMap<UpdateTaxDto, Tax>();
            #endregion

            #region Taxable
            CreateMap<Taxable, TaxableDto>();
            CreateMap<CreateTaxableDto, Taxable>();
            CreateMap<UpdateTaxableDto, Taxable>();
            #endregion
        }

    }
}
