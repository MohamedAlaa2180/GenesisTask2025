using System.Collections.Generic;
using System.Linq;
using Task_Player;

namespace Task_Environment
{
    public class EnvironmentDesert : Environment
    {
        private float fireDamageConvertionRate = 0.15f;
        private float flatDamage = 20f;
        public override EnvironmentType Type => EnvironmentType.Desert;

        public override Player ApplyEffectOnPlayer(Player player)
        {
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Physical)?.DecreaseByValue(12f);
            return player;
        }

        public override List<Damage> ApplyEffectOnDamageType(Damage damage)
        {
            float totalAttackValue = damage.DamageAmount;

            DamageFire fireDamage = new DamageFire(totalAttackValue * fireDamageConvertionRate);
            damage.DamageAmount -= fireDamage.DamageAmount;

            return new List<Damage>
        {
            fireDamage,damage
        };
        }

        public override float ApplyEffectOnDamageValue(float damage)
        {
            //Add flat damage
            damage += flatDamage;
            return damage;
        }
    }
}