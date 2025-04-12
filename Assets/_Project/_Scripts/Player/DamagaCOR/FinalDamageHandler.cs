using System.Linq;
using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class FinalDamageHandler : DamageHandler
    {
        private readonly FactoryBase<DamageType, Damage> _damageFactory;
        private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;

        public FinalDamageHandler()
        {
            _damageFactory = new DamageFactory();
            _environmentFactory = new EnvironmentFactory();
        }

        public override DamageResult Handle(Player attacker, Player defender, DamageResult inputDamage, EnvironmentType environmentType, DamageType damageType)
        {
            Damage baseDamageType = _damageFactory.Create(damageType, inputDamage.ElementalDamage);
            var environment = _environmentFactory.Create(environmentType);

            // Apply the environment effect to the damage
            var damageList = environment.ApplyEffectOnDamageType(baseDamageType);

            inputDamage.ElementalDamage = 0;
            for (int i = 0; i < damageList.Count; i++)
            {
                var damage = damageList[i];
                damage = ApplyResistance(defender, damage);
                damage.ApplyEffect(defender);
                inputDamage.ElementalDamage += damage.DamageAmount;
            }

            return _next?.Handle(attacker, defender, inputDamage, environmentType, damageType) ?? inputDamage;
        }

        private Damage ApplyResistance(Player defender, Damage damage)
        {
            float resistanceValue = defender.Resistances.FirstOrDefault(r => r.Type == damage.Type)?.GetResistance() ?? 0f;
            float blockedDamage = damage.DamageAmount * resistanceValue;
            damage.DamageAmount -= blockedDamage;
            return damage;
        }
    }
}