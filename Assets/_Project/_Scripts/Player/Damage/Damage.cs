namespace Task_Player
{
    public abstract class Damage
    {
        /// <summary>
        /// Gets the type of damage (e.g., Physical, Fire, Ice, Poison).
        /// This property is implemented by subclasses to define the specific damage type.
        /// </summary>
        public abstract DamageType Type { get; }

        /// <summary>
        /// The amount of damage being dealt.
        /// This value is modified through various effects, such as buffs, debuffs, and environmental influences.
        /// </summary>
        public float DamageAmount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class with a specified damage amount.
        /// </summary>
        /// <param name="amount">The initial amount of damage to be dealt.</param>
        protected Damage(float amount)
        {
            DamageAmount = amount;
        }

        /// <summary>
        /// Applies specific effects to the target player based on the damage type.
        /// This could involve adjusting the target's health, applying resistances, etc.
        /// </summary>
        /// <param name="target">The player receiving the damage.</param>
        public abstract void ApplyEffect(Player target);
    }
}