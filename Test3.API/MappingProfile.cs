using AutoMapper;
using Test3.Models;
namespace Test3.API;

public class MappingProfile: Profile
{
     public MappingProfile()
    {
        CreateMap<CentresDTO, Centres>().ForMember(
                    dest => dest.Centre,
                    opt => opt.MapFrom(src => src.CentreName)
                ).ForMember(
                    dest => dest.State,
                    opt => opt.MapFrom(src => src.StateName)
                );
        CreateMap<CentresDTO, Centres>().ForMember(
                    dest => dest.Centre,
                    opt => opt.MapFrom(src => src.CentreName)
                ).ForMember(
                    dest => dest.State,
                    opt => opt.MapFrom(src => src.StateName)
                ).ReverseMap();
    }
}
