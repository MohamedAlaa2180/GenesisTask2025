using System.Collections.Generic;

namespace Task_Player
{
    public class Player
    {
        public float AttackPower { get; set; }
        public float WeaponStrength { get; set; }
        public List<Resistance> Resistances { get; set; }
        public List<StatusEffect> ActiveBuffs { get; set; }
        public List<StatusEffect> ActiveDebuffs { get; set; }

        public float PureDamage => AttackPower + WeaponStrength;

        public Player()
        {
            Resistances = new List<Resistance>();
            ActiveBuffs = new List<StatusEffect>();
            ActiveDebuffs = new List<StatusEffect>();
        }
    }
}