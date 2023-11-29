using _net.Dtos;
using _net.Dtos.Weapon;
using _net.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _net.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController: ControllerBase
    {

        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> AddWeapon(
            WeaponRequestDto weaponRequestDto)
        {
            return Ok(await _weaponService.AddWeapon(weaponRequestDto));
        }
    }
}
