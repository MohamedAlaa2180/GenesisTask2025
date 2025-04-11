using Task_Player;
using UnityEngine;

public class ResistanceIce : Resistance
{
    public override DamageType Type => DamageType.Ice;
    public ResistanceIce(float amount) : base(amount) { }
}
