using _net.Dtos;
using AutoMapper;

namespace _net
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterResponseDto>();
            CreateMap<CharacterRequestDto, Character>();
        }
    }
}