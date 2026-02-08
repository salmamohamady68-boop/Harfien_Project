using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Harfien.Application.DTO;
using Harfien.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Harfien.Application.Mappings
{
    public class ServiceProfile:Profile
    {
      public  ServiceProfile() { 
            CreateMap<Service,ServiceCreateDto>().ReverseMap();
            
            CreateMap<Service,ServiceUpdateDto>().ReverseMap();
            CreateMap<Service, ServiceReadDto>()
           .ForMember(dest => dest.CraftsmanName, opt => opt.MapFrom(src => src.Craftsman.User.UserName))
           .ForMember(dest => dest.ServiceCategoryName, opt => opt.MapFrom(src => src.ServiceCategory.Name)).ReverseMap();


        }
    }
}
