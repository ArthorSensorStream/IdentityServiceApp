using AutoMapper;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.DTOs
{
    public class IdentityMapProfile : Profile
    {
        public IdentityMapProfile()
        {
            CreateMap<IdentityItem, IdentityItemDto>().ReverseMap();
            CreateMap<IdentityItem, UpdateIdentityDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();
            CreateMap<IdentityItem, CreateIdentityItemDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate)).ReverseMap();
        }
    }
}
