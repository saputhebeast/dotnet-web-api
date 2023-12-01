using _net.Dtos.Skill;
using _net.Dtos.Weapon;

namespace _net.Dtos
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Fredo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public WeaponResponseDto? Weapon { get; set; }
        public List<SkillResponseDto>? Skills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
