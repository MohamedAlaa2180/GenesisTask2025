namespace Task_Player
{
    /// <summary>
    /// Represents a status effect applied to a player, which modifies damage calculations.
    /// </summary>
    public class StatusEffect
    {
        /// <summary>
        /// The name of the status effect (e.g., "Poisoned", "Buffed").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The multiplier that modifies the player's damage based on the effect.
        /// A value greater than 1 increases damage, while a value less than 1 decreases it.
        /// </summary>
        public float DamageMultiplier { get; set; }

        /// <summary>
        /// Stores the original damage multiplier to revert the effect later.
        /// </summary>
        private float _originalDamageMultiplier;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusEffect"/> class with the specified name and damage multiplier.
        /// </summary>
        /// <param name="name">The name of the status effect.</param>
        /// <param name="damageMultiplier">The multiplier that will modify the damage calculation for the player.</param>
        public StatusEffect(string name, float damageMultiplier)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
            _originalDamageMultiplier = damageMultiplier; // Store the original value for future reset.
        }

        /// <summary>
        /// Creates a clone of the current status effect.
        /// Useful for duplicating effects when applied to different targets.
        /// </summary>
        /// <returns>A new <see cref="StatusEffect"/> object that is a copy of the current one.</returns>
        public StatusEffect Clone()
        {
            return new StatusEffect(this.Name, this.DamageMultiplier);
        }

        /// <summary>
        /// Modifies the damage multiplier by a given ratio.
        /// For example, a value of 0.1 increases the multiplier by 10%.
        /// </summary>
        /// <param name="value">The ratio to modify the damage multiplier by (positive or negative).</param>
        public void ModifyMultiplierByRatio(float value) => DamageMultiplier += DamageMultiplier * value;

        /// <summary>
        /// Disables the status effect by setting the damage multiplier to 1.
        /// This effectively nullifies the effect.
        /// </summary>
        public void DisableEffect() => DamageMultiplier = 1f;

        /// <summary>
        /// Re-enables the status effect by restoring the original damage multiplier.
        /// </summary>
        public void EnableEffect() => DamageMultiplier = _originalDamageMultiplier;

        /// <summary>
        /// Gets the effect value, which is the difference between the current multiplier and the base (1).
        /// This can be used to determine how much the status effect is modifying the damage.
        /// </summary>
        public float GetEffectValue => DamageMultiplier - 1;
    }
}
