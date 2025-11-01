using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Mappings
{
    public class RegulationFacilityProfile : Profile
    {
        public RegulationFacilityProfile()
        {
            CreateMap<RegulationFacilityDto, RegulationFacility>();
        }
    }
}