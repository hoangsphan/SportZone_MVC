using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Mappings
{
    public class FieldPricingProfile : Profile
    {
        public FieldPricingProfile()
        {
            CreateMap<FieldPricing, FieldPricingDto>()
                .ForMember(dest => dest.PricingId, opt => opt.MapFrom(src => src.PricingId))
                .ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.FieldId))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
