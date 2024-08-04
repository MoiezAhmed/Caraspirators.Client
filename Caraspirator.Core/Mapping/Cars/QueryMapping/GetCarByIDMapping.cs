using Caraspirator.Core.Feature.Cars.Queries.Result;
using Caraspirator.Core.Feature.Parts.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Mapping.Cars;

public partial class CarProfile
{
    public void GetCarByIDMapping()
    {

        CreateMap<Car, GetSingleCarResponse>()
           .ForMember(dest => dest.CarID, opt => opt.MapFrom(src => src.CarID))
           .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.CarModel))
           .ForMember(dest => dest.CarMake, opt => opt.MapFrom(src => src.CarMake))
           .ForMember(dest => dest.CarYear, opt => opt.MapFrom(src => src.CarYear))
           //.ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.CarPart))
          .ReverseMap();

         // CreateMap<CarPart, GetSinglePartResponse>()
         //.ForMember(dest => dest.PartID, opt => opt.MapFrom(src => src.PartID))
         //  .ForMember(dest => dest.PartName, opt => opt.MapFrom(src => src.Part.Localize(src.Part.PartTrans.LastOrDefault().ParttransName, src.Part.PartTrans.FirstOrDefault().ParttransName)))
         //  .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Part.Manufacturer))
       ;
    }
}
