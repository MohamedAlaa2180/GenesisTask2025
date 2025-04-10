using Task_Player;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Damage
{
    public abstract DamageType Type { get; }
    public float DamageAmount { get; set; }

    protected Damage(float amount)
    {
        DamageAmount = amount;
    }

    public abstract void ApplyEffect(Player target);
}
