using System.Collections.Generic;
using System.Linq;
using Task_Player;

namespace Task_Environment
{
    public class EnvironmentForest : Environment
    {
        public override EnvironmentType Type => EnvironmentType.Forest;

        public override Player ApplyEffectOnPlayer(Player player)
        {
            player.WeaponStrength -= player.WeaponStrength * 0.18f;
            player.Resistances.FirstOrDefault(r => r.Type == DamageType.Fire)?.SetResistance(0f);
            return player;
        }

        public override List<Damage> ApplyEffectOnDamageType(Damage damage)
        {
            return new List<Damage>
        {
            damage
        };
        }
    }
}