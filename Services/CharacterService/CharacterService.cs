using _net.Dtos;
using AutoMapper;

namespace _net.Services.CharacterService
{
    public class CharacterService: ICharacterService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;
        
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                if (character is null)
                    throw new Exception($"character with id '{updatedCharacter.Id}' not found");

                _mapper.Map(updatedCharacter, character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();

            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                if (character is null)
                    throw new Exception($"Character with Id '{id}' not found.");

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
