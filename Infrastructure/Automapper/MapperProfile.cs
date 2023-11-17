using AutoMapper;
using Domain.DTOs.CardDTOs;
using Domain.DTOs.OwnerDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<User, GetUserDto>()
            .ForMember(go => go.Status, opt => opt.MapFrom(o => o.StatusUser.ToString()));
        CreateMap<Card, GetCardDto>();
    }
}
