using Task_Player;
using UnityEngine;

public class DamageIce : Damage
{

    public override DamageType Type => DamageType.Ice;
    public DamageIce(float amount) : base(amount) { }
    public override void ApplyEffect(Player target)
    {
        Debug.Log($"Player {target} recieved damage of type {Type.ToString()} with amount {DamageAmount}");
    }
}

