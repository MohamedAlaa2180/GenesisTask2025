namespace Task_Player
{
    public abstract class Resistance
    {
        /// <summary>
        /// Gets the type of resistance (e.g., Physical, Fire, Ice, Poison).
        /// This property is implemented by subclasses to define the specific resistance type.
        /// </summary>
        public abstract DamageType Type { get; }

        /// <summary>
        /// The amount of resistance the player has against the damage type.
        /// This value is affected by various effects like buffs, debuffs, and environmental factors.
        /// </summary>
        public float ResistanceAmount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resistance"/> class with a specified resistance amount.
        /// </summary>
        /// <param name="amount">The initial amount of resistance to be applied against the damage type.</param>
        protected Resistance(float amount)
        {
            ResistanceAmount = amount;
        }

        /// <summary>
        /// Creates a clone of this resistance instance.
        /// This is useful for duplicating resistance data when creating a new player or applying effects.
        /// </summary>
        /// <returns>A cloned instance of the resistance.</returns>
        public abstract Resistance Clone();

        /// <summary>
        /// Increases the resistance amount by a specified value.
        /// </summary>
        /// <param name="value">The value to increase the resistance by.</param>
        public void IncreaseByValue(float value) => ResistanceAmount += value;

        /// <summary>
        /// Increases the resistance amount by a specified ratio.
        /// </summary>
        /// <param name="value">The ratio by which the resistance should be increased (e.g., 0.1 for a 10% increase).</param>
        public void IncreaseByRatio(float value) => ResistanceAmount += ResistanceAmount * value;

        /// <summary>
        /// Decreases the resistance amount by a specified value.
        /// </summary>
        /// <param name="value">The value to decrease the resistance by.</param>
        public void DecreaseByValue(float value) => ResistanceAmount -= value;

        /// <summary>
        /// Decreases the resistance amount by a specified ratio.
        /// </summary>
        /// <param name="value">The ratio by which the resistance should be decreased (e.g., 0.1 for a 10% decrease).</param>
        public void DecreaseByRatio(float value) => ResistanceAmount -= ResistanceAmount * value;

        /// <summary>
        /// Sets the resistance to a specified value.
        /// </summary>
        /// <param name="value">The value to set the resistance to.</param>
        public void SetResistance(float value) => ResistanceAmount = value;

        /// <summary>
        /// Calculates the effective resistance factor as a fraction.
        /// This is typically used to modify damage calculations.
        /// </summary>
        /// <returns>
        /// A float representing the effective resistance factor, calculated as:
        /// ResistanceAmount / (ResistanceAmount + 100f)
        /// </returns>
        public float GetResistance() => ResistanceAmount / (ResistanceAmount + 100f);
    }
}