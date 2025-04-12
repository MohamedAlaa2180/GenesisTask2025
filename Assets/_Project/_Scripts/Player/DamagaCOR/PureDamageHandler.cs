using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class PureDamageHandler : DamageHandler
    {
        public override DamageResult Handle(Player attacker, Player defender, DamageResult inputDamage, EnvironmentType envType, DamageType dmgType)
        {
            inputDamage.AddElementalDamage(attacker.PureDamage);
            return _next?.Handle(attacker, defender, inputDamage, envType, dmgType) ?? inputDamage;
        }
    }
}