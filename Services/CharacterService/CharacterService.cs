﻿using _net.Dtos;
using AutoMapper;

namespace _net.Services.CharacterService
{
    public class CharacterService: ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Sam"}
        };

        private readonly IMapper _mapper;
        
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
