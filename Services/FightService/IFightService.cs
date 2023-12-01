using _net.Dtos.Fight;

namespace _net.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto weaponAttackDto);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto skillAttackDto);
        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto fightRequestDto);
        Task<ServiceResponse<List<HighScoreDto>>> GetHighScore();
    }
}
