using _net.Dtos.Fight;

namespace _net.Services.FightService
{
    public class FightService: IFightService
    {

        private readonly DataContext _dataContext;
        
        public FightService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto weaponAttackDto)
        {
            var response = new ServiceResponse<AttackResultDto>();
            try
            {
                var attacker = await _dataContext.Characters
                    .Include(c => c.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == weaponAttackDto.AttackerId);
                var opponent = await _dataContext.Characters
                    .FirstOrDefaultAsync(c => c.Id == weaponAttackDto.OpponentId);

                if (attacker is null || opponent is null || attacker.Weapon is null)
                    throw new Exception("Something fishy is going on here...");
                
                int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
                damage -= new Random().Next(opponent.Defeats);

                if (damage > 0)
                    opponent.HitPoints -= damage;

                if (opponent.HitPoints <= 0)
                    response.Message = $"{opponent.Name} has been defeated!";

                await _dataContext.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = opponent.Name,
                    AttackerHP = attacker.HitPoints,
                    OpponentHP = opponent.HitPoints,
                    Damage = damage
                };
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
