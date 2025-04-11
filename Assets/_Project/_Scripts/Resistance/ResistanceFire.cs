using Task_Player;
using UnityEngine;

public class ResistanceFire : Resistance
{
    public override DamageType Type => DamageType.Fire;
    public ResistanceFire(float amount) : base(amount) { }
}
