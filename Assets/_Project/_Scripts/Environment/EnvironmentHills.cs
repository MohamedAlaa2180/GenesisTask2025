using System.Collections.Generic;
using System.Linq;
using Task_Player;
using Unity.VisualScripting;

namespace Task_Environment
{
    public class EnvironmentHills : Environment
    {
        public override EnvironmentType Type => EnvironmentType.Hills;

        public override Player ApplyEffectOnPlayer(Player player)
        {
            // Disable Debuffs
            foreach (var deBuff in player.ActiveDebuffs)
            {
                deBuff.DisableEffect();
            }
            // +100% Buffs Power
            foreach (var buff in player.ActiveBuffs)
            {
                buff.ModifyMultiplierByRatio(1f);
            }
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