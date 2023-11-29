using System.Security.Claims;
using _net.Dtos;
using _net.Dtos.Weapon;
using AutoMapper;

namespace _net.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {

        private readonly DataContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<CharacterResponseDto>> AddWeapon(WeaponRequestDto weaponRequestDto)
        {
            var response = new ServiceResponse<CharacterResponseDto>();
            try
            {
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == weaponRequestDto.CharacterId &&
                                              c.User!.Id == int.Parse(_httpContextAccessor.HttpContext!.User
                                                  .FindFirstValue(ClaimTypes.NameIdentifier)!));
                if (character is null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                    return response;
                }

                var weapon = new Weapon
                {
                    Name = weaponRequestDto.Name,
                    Damage = weaponRequestDto.Damage,
                    Character = character
                };
                _context.Weapons.Add(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<CharacterResponseDto>(character);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }
    }
}