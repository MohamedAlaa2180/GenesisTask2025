using Task_Player;

public class ResistanceFire : Resistance
{
    public override DamageType Type => DamageType.Fire;

    public ResistanceFire(float amount) : base(amount)
    {
    }
}