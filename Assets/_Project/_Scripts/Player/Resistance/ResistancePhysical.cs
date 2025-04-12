using Task_Player;

public class ResistancePhysical : Resistance
{
    public override DamageType Type => DamageType.Physical;

    public ResistancePhysical(float amount) : base(amount)
    {
    }

    public override Resistance Clone()
    {
        return new ResistancePhysical(this.ResistanceAmount);
    }
}