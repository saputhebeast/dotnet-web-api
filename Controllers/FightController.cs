﻿using _net.Dtos.Fight;
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
        
        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto skillAttackDto)
        {
            return Ok(await _fightService.SkillAttack(skillAttackDto));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> Fight(FightRequestDto fightRequestDto)
        {
            return Ok(await _fightService.Fight(fightRequestDto));
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HighScoreDto>>>> HighScore()
        {
            return Ok(await _fightService.GetHighScore());
        }
    }
}
