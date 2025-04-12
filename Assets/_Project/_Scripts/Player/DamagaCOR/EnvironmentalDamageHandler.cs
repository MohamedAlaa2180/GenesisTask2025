using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    public class EnvironmentalDamageHandler : DamageHandler
    {
        private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;

        public EnvironmentalDamageHandler()
        {
            _environmentFactory = new EnvironmentFactory();
        }

        public override DamageResult Handle(Player attacker, Player defender, DamageResult inputDamage, EnvironmentType environmentType, DamageType dmgType)
        {
            var environment = _environmentFactory.Create(environmentType);

            attacker = environment.ApplyEffectOnPlayer(attacker);
            defender = environment.ApplyEffectOnPlayer(defender);

            inputDamage.AddFlatDamage(attacker.FlatDamage);

            return _next?.Handle(attacker, defender, inputDamage, environmentType, dmgType) ?? inputDamage;
        }
    }
}