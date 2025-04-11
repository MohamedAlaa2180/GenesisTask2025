using Task_Player;
using UnityEngine;

public class ResistancePoison : Resistance
{
    public override DamageType Type => DamageType.Poison;
    public ResistancePoison(float amount) : base(amount) { }
}
