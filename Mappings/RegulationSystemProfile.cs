using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Mappings
{
    public class RegulationSystemProfile : Profile
    {
        public RegulationSystemProfile()
        {
            CreateMap<RegulationSystemDto, RegulationSystem>();
        }
    }
}