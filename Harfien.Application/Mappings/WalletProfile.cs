using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Harfien.Application.DTO.Order;
using Harfien.Application.DTO.Payment;
using Harfien.Domain.Entities;

namespace Harfien.Application.Mappings
{
    public class WalletProfile:Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletTransaction, WalletTransactionDto>()
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Reason,
                opt => opt.MapFrom(src => src.TransactionReason))
            .ForMember(dest => dest.Orderinfo,
             opt => opt.MapFrom(src => src.Order));
            //.ForMember(dest => dest.OrderDetails,
            //    opt => opt.MapFrom(src => src.Order))


            CreateMap<Order, OrderInfoDto>()
               .ForMember(d => d.OrderId, o => o.MapFrom(s => s.Id))
               .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Client != null && s.Client.User != null
                   ? s.Client.User.FullName
                   : "N/A"))
               .ForMember(d => d.CraftsmanName, o => o.MapFrom(s => s.Craftsman != null && s.Craftsman.User != null
                   ? s.Craftsman.User.FullName
                   : "N/A"))
               .ForMember(d => d.ServiceName, o => o.MapFrom(s => s.Service != null
                   ? s.Service.Name
                   : "N/A"))
               .ForMember(d => d.OrderStatus, o => o.MapFrom(s => s.Status));

//            CreateMap<Order, OrderDetailsDto>()
//                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
//                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
//                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
//                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
//                    .ForMember(dest => dest.CraftsmanName, opt => opt.MapFrom(src => src.Craftsman != null ? src.Craftsman.User.FullName : null))
//;
            CreateMap<Wallet, WalletDto>();
                
        }
    }
}
