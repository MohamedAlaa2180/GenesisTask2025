using System.Linq;
using Task_Environment;
using Task_Player;

public class BaseDamageHandler : DamageHandler
{
    public override float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType envType, DamageType dmgType)
    {
        float effectMultiplier = attacker.ActiveBuffs.Sum(b => b.GetEffectValue) - attacker.ActiveDebuffs.Sum(d => d.GetEffectValue);
        float baseDamage = inputDamage + (inputDamage * effectMultiplier);
        return _next?.Handle(attacker, defender, baseDamage, envType, dmgType) ?? baseDamage;
    }
}
