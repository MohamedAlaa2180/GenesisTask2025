using System.Linq;
using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class BaseDamageHandler : DamageHandler
    {
        public override DamageResult Handle(Player attacker, Player defender, DamageResult inputDamage, EnvironmentType envType, DamageType dmgType)
        {
            float effectMultiplier = attacker.ActiveBuffs.Sum(b => b.GetEffectValue) - attacker.ActiveDebuffs.Sum(d => d.GetEffectValue);
            inputDamage.AddElementalDamage(attacker.PureDamage * effectMultiplier);
            return _next?.Handle(attacker, defender, inputDamage, envType, dmgType) ?? inputDamage;
        }
    }
}