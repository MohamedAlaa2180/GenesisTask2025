using Task_Player;
using UnityEngine;

public class DamagePhysical : Damage
{
    public override DamageType Type => DamageType.Physical;
    public DamagePhysical(float amount) : base(amount) { }

    public override void ApplyEffect(Player target)
    {
        Debug.Log($"Player {target} recieved damage of type {Type.ToString()} with amount {DamageAmount}");
    }
}
