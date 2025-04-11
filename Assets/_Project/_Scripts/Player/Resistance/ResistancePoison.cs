using Task_Player;

public class ResistancePoison : Resistance
{
    public override DamageType Type => DamageType.Poison;

    public ResistancePoison(float amount) : base(amount)
    {
    }
}