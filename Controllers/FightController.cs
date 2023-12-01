using _net.Dtos.Fight;
using _net.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace _net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {

        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto weaponAttackDto)
        {
            return Ok(await _fightService.WeaponAttack(weaponAttackDto));
        }
    }
}