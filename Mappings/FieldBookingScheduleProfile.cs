using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Mappings
{
    public class FieldBookingScheduleProfile : Profile
    {
        public FieldBookingScheduleProfile()
        {
            CreateMap<FieldBookingSchedule, FieldBookingScheduleDto>().ReverseMap();
            //CreateMap<FieldBookingScheduleUpdateDto, FieldBookingSchedule>();
            CreateMap<FieldBookingScheduleUpdateGenerateDto, FieldBookingSchedule>();

            CreateMap<FieldPricingDto, FieldPricing>().ReverseMap();
            CreateMap<FieldPricingCreateDto, FieldPricing>();
            CreateMap<FieldPricingUpdateDto, FieldPricing>();
        }
    }
}
