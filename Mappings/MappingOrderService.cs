using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Mappings
{
    public class MappingOrderService : Profile
    {
        public MappingOrderService()
        {
            // OrderService Entity to DTO
            CreateMap<OrderService, OrderServiceDTO>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service != null ? src.Service.ServiceName : null))
                .ForMember(dest => dest.ServiceImage, opt => opt.MapFrom(src => src.Service != null ? src.Service.Image : null))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => (src.Price ?? 0) * src.Quantity));

            // DTO to OrderService Entity (for create)
            CreateMap<OrderServiceCreateDTO, OrderService>()
                .ForMember(dest => dest.OrderServiceId, opt => opt.Ignore()) // Auto-generated
                .ForMember(dest => dest.Order, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.Service, opt => opt.Ignore()); // Navigation property

            // DTO to OrderService Entity (for update)
            CreateMap<OrderServiceUpdateDTO, OrderService>()
                .ForMember(dest => dest.OrderServiceId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Service, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
