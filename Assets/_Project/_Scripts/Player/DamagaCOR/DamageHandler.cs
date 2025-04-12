using Task_Environment;
using Task_Player;

namespace Task_DamageCORPattern
{
    /// <summary>
    /// Abstract base class for handling damage calculation in a chain of responsibility pattern.
    /// Each handler in the chain is responsible for applying specific logic to the damage calculation.
    /// </summary>
    public abstract class DamageHandler
    {
        /// <summary>
        /// The next handler in the chain of responsibility.
        /// </summary>
        protected DamageHandler _next;

        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="next">The next <see cref="DamageHandler"/> in the chain.</param>
        public void SetNext(DamageHandler next)
        {
            _next = next;
        }

        /// <summary>
        /// Handles the damage calculation process. This method must be implemented by derived classes.
        /// </summary>
        /// <param name="attacker">The player initiating the attack.</param>
        /// <param name="defender">The player receiving the damage.</param>
        /// <param name="inputDamage">The initial damage value passed along the chain.</param>
        /// <param name="environmentType">The environment type where the damage occurs (used by environment-based handlers).</param>
        /// <param name="damageType">The type of damage being dealt (e.g., physical, fire, ice, poison).</param>
        /// <returns>The modified damage after applying any relevant effects, or the value passed down the chain.</returns>
        public abstract DamageResult Handle(Player attacker, Player defender, DamageResult inputDamage, EnvironmentType environmentType, DamageType damageType);
    }

    public struct DamageResult
    {
        public float ElementalDamage { get; set; }
        public float FlatDamage { get; set; }

        public DamageResult(float elementalDamage, float flatDamage)
        {
            ElementalDamage = elementalDamage;
            FlatDamage = flatDamage;
        }

        public void AddElementalDamage(float value) => ElementalDamage += value;
        public void AddFlatDamage(float value) => FlatDamage += value;

        public float TotalDamage => ElementalDamage + FlatDamage;
    }
}