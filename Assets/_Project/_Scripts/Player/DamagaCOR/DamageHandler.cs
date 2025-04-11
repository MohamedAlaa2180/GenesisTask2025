using Task_Environment;
using Task_Player;

public abstract class DamageHandler
{
    protected DamageHandler _next;

    public void SetNext(DamageHandler next)
    {
        _next = next;
    }

    public abstract float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType envType, DamageType dmgType);
}
