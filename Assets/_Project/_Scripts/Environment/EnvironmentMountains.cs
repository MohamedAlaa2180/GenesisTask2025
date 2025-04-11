using System.Collections.Generic;
using System.Linq;
using Task_Player;

namespace Task_Environment
{
    public class EnvironmentMountains : Environment
    {
        public override EnvironmentType Type => EnvironmentType.Mountains;

        public override Player ApplyEffectOnPlayer(Player player)
        {
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Physical)?.IncreaseByValue(50f);
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Fire)?.IncreaseByValue(50f);
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Ice)?.IncreaseByValue(50f);
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Poison)?.IncreaseByValue(50f);

            return player;
        }

        public override List<Damage> ApplyEffectOnDamageType(Damage damage)
        {
            damage.DamageAmount = damage.Type == DamageType.Ice ? 0 : damage.DamageAmount;

            return new List<Damage>
        {
            damage
        };
        }

        public override float ApplyEffectOnDamageValue(float damage)
        {
            return damage;
        }
    }
}