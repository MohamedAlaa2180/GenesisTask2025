using System.Collections.Generic;

namespace Task_Player
{
    public enum DamageType { Physical, Fire, Ice, Poison }
    public enum EnvironmentType { Desert, Mountains, Forest, Hills }

    public class Player
    {
        public float AttackPower { get; set; }
        public float WeaponStrength { get; private set; }
        public PlayerResistance Resistance { get; private set; }
        public List<StatusEffect> ActiveBuffs { get; private set; }
        public List<StatusEffect> ActiveDebuffs { get; private set; }

        public Player(float attackPower = 0, float weaponStrength = 0, PlayerResistance resistance = null)
        {
            AttackPower = attackPower;
            WeaponStrength = weaponStrength;
            Resistance = resistance;
            ActiveBuffs = new List<StatusEffect>();
            ActiveDebuffs = new List<StatusEffect>();
        }
    }
}