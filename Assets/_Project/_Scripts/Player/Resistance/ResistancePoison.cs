using Task_Player;

public class ResistancePoison : Resistance
{
    public override DamageType Type => DamageType.Poison;

    public ResistancePoison(float amount) : base(amount)
    {
    }

    public override Resistance Clone()
    {
        return new ResistancePoison(this.ResistanceAmount);
    }
}