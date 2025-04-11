using System;
using Task_Player;
using UnityEngine;

[Serializable]
public class DamageFire : Damage
{
    public override DamageType Type => DamageType.Fire;

    public DamageFire(float amount) : base(amount)
    {
    }

    public override void ApplyEffect(Player target)
    {
        Debug.Log($"Player {target} recieved damage of type {Type.ToString()} with amount {DamageAmount}");
    }
}