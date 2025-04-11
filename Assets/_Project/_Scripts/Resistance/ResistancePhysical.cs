using Task_Player;
using UnityEngine;

public class ResistancePhysical : Resistance
{
    public override DamageType Type => DamageType.Physical;
    public ResistancePhysical(float amount) : base(amount) { }
}
