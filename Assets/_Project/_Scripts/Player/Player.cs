using System.Collections.Generic;
using System.Linq;

namespace Task_Player
{
    public class Player
    {
        public float AttackPower { get; set; }
        public float WeaponStrength { get; set; }
        public float FlatDamage { get; private set; }
        public List<Resistance> Resistances { get; set; }
        public List<StatusEffect> ActiveBuffs { get; set; }
        public List<StatusEffect> ActiveDebuffs { get; set; }

        public float PureDamage => AttackPower + WeaponStrength;

        public Player()
        {
            Resistances = new List<Resistance>()
            {
                new ResistancePhysical(0f),
                new ResistanceFire(0f),
                new ResistanceIce(0f),
                new ResistancePoison(0f)
            };
            ActiveBuffs = new List<StatusEffect>();
            ActiveDebuffs = new List<StatusEffect>();
        }

        public Player Clone()
        {
            return new Player
            {
                AttackPower = this.AttackPower,
                WeaponStrength = this.WeaponStrength,
                Resistances = this.Resistances.Select(r => r.Clone()).ToList(),
                ActiveBuffs = this.ActiveBuffs.Select(b => b.Clone()).ToList(),
                ActiveDebuffs = this.ActiveDebuffs.Select(d => d.Clone()).ToList()
            };
        }

        public void AddFlatDamage(float value)
        {
            FlatDamage += value;
        }
    }
}