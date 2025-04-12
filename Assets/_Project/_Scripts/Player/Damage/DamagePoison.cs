using UnityEngine;

namespace Task_Player
{
    public class DamagePoison : Damage
    {
        public override DamageType Type => DamageType.Poison;

        public DamagePoison(float amount) : base(amount)
        {
        }

        public override void ApplyEffect(Player target)
        {
            Debug.Log($"Player {target} recieved damage of type {Type.ToString()} with amount {DamageAmount}");
        }
    }
}