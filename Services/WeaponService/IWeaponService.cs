using _net.Dtos;
using _net.Dtos.Weapon;

namespace _net.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<CharacterResponseDto>> AddWeapon(WeaponRequestDto weaponRequestDto);
    }
}