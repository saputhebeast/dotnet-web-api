using _net.Dtos;

namespace _net.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters();
        Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter);
        Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<CharacterResponseDto>> AddCharacterSkill(CharacterSkillsRequestDto characterSkillsRequestDto);
    }
}
