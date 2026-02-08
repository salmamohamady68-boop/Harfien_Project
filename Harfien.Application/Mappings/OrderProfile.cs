using AutoMapper;
using Harfien.Application.DTOs;
using Harfien.Domain.Entities;

namespace Harfien.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.ClientId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<Order, OrderResponseDto>()
                .ForMember(d => d.ServiceName,
                    o => o.MapFrom(s => s.Service != null ? s.Service.Name : "N/A"))
                .ForMember(d => d.ClientName,
                    o => o.MapFrom(c => c.Client != null && c.Client.User != null
                        ? c.Client.User.FullName
                        : "N/A"))
                .ForMember(d => d.CraftsmanName,
                    o => o.MapFrom(c => c.Craftsman != null && c.Craftsman.User != null
                        ? c.Craftsman.User.FullName
                        : "N/A"));
        }
    }
}