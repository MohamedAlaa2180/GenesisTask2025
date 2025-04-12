using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class PureDamageHandler : DamageHandler
    {
        public override float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType envType, DamageType dmgType)
        {
            float pureDamage = attacker.PureDamage + inputDamage;
            return _next?.Handle(attacker, defender, pureDamage, envType, dmgType) ?? pureDamage;
        }
    }
}