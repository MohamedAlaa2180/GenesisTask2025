using System.Linq;
using Task_Environment;
using Task_Player;

public class FinalDamageStrategy : ChainedDamageCalculationStrategy
{
    public FinalDamageStrategy()
    {
        var pureDamageHandler = new PureDamageHandler();
        var baseDamageHandler = new BaseDamageHandler();
        var environmentalDamageHandler = new EnvironmentalDamageHandler();
        var finalDamageHandler = new FinalDamageHandler();

        // Set up the chain
        pureDamageHandler.SetNext(baseDamageHandler);
        baseDamageHandler.SetNext(environmentalDamageHandler);
        environmentalDamageHandler.SetNext(finalDamageHandler);

        _chainHead = pureDamageHandler;
    }

    public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        return _chainHead.Handle(attacker, defender, 0f, environmentType, damageType);
    }
}
