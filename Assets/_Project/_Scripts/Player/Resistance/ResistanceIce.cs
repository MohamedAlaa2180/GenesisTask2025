using Task_Player;

public class ResistanceIce : Resistance
{
    public override DamageType Type => DamageType.Ice;

    public ResistanceIce(float amount) : base(amount)
    {
    }

    public override Resistance Clone()
    {
        return new ResistanceIce(this.ResistanceAmount);
    }
}