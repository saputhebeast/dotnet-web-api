using _net.Dtos;
using _net.Dtos.Weapon;
using AutoMapper;

namespace _net
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterResponseDto>();
            CreateMap<CharacterRequestDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Weapon, WeaponResponseDto>();
        }
    }
}
