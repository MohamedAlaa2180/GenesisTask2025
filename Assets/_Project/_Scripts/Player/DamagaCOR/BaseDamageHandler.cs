using System.Linq;
using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class BaseDamageHandler : DamageHandler
    {
        public override float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType envType, DamageType dmgType)
        {
            float effectMultiplier = attacker.ActiveBuffs.Sum(b => b.GetEffectValue) - attacker.ActiveDebuffs.Sum(d => d.GetEffectValue);
            float baseDamage = inputDamage + (attacker.PureDamage * effectMultiplier);
            return _next?.Handle(attacker, defender, baseDamage, envType, dmgType) ?? baseDamage;
        }
    }
}