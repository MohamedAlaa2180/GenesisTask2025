using Task_Environment;

namespace Task_Player
{
    /// <summary>
    /// Coordinates combat interactions between two players by delegating damage calculations
    /// to specific strategy implementations (pure, base, environmental, final).
    /// Clones the attacker and defender on construction to preserve original state.
    /// </summary>
    public class PlayerCombat
    {
        // Cloned attacker and defender instances used for damage computations
        private readonly Player _attacker;
        private readonly Player _defender;

        // Strategy instances for each damage calculation phase
        private readonly IDamageCalculationStrategy _pureDamageStrategy;
        private readonly IDamageCalculationStrategy _baseDamageStrategy;
        private readonly IDamageCalculationStrategy _environmentalDamageStrategy;
        private readonly IDamageCalculationStrategy _finalDamageStrategy;

        /// <summary>
        /// Initializes a new instance of <see cref="PlayerCombat"/> with the given attacker and defender.
        /// Clones both players to avoid mutating original objects during calculations.
        /// </summary>
        /// <param name="attacker">The player who will perform the attack.</param>
        /// <param name="defender">The player who will receive damage.</param>
        public PlayerCombat(Player attacker, Player defender)
        {
            // Clone input players to maintain immutability of external state
            _attacker = attacker.Clone();
            _defender = defender.Clone();

            // Instantiate strategies for each calculation phase
            _pureDamageStrategy = new PureDamageStrategy();
            _baseDamageStrategy = new BaseDamageStrategy();
            _environmentalDamageStrategy = new EnvironmentalDamageStrategy();
            _finalDamageStrategy = new FinalDamageStrategy();
        }

        /// <summary>
        /// Calculates the pure damage (attack power + weapon strength) without any modifiers.
        /// </summary>
        /// <returns>The pure damage value.</returns>
        public float CalculatePureDamage()
        {
            return _pureDamageStrategy.CalculateDamage(_attacker, _defender);
        }

        /// <summary>
        /// Calculates the base damage by applying buffs and debuffs to the pure damage.
        /// Ignores environmental factors and resistances.
        /// </summary>
        /// <returns>The base damage value after status effects.</returns>
        public float CalculateBaseDamage()
        {
            return _baseDamageStrategy.CalculateDamage(_attacker, _defender);
        }

        /// <summary>
        /// Calculates damage after applying buffs, debuffs, and environment-specific modifiers.
        /// Does not account for defender resistances.
        /// </summary>
        /// <param name="environmentType">The environment in which the attack takes place.</param>
        /// <returns>The damage value including environmental effects.</returns>
        public float CalculateEnvironmentalDamage(EnvironmentType environmentType)
        {
            return _environmentalDamageStrategy.CalculateDamage(_attacker, _defender, environmentType);
        }

        /// <summary>
        /// Calculates the final damage dealt to the defender, including all factors:
        /// pure damage, status effects, environment modifiers, and defender resistances.
        /// </summary>
        /// <param name="environmentType">The environment in which the attack takes place.</param>
        /// <param name="damageType">The type of damage being dealt (Physical, Fire, Ice, Poison).</param>
        /// <returns>The final damage value after resistance mitigation.</returns>
        public float CalculateFinalDamage(EnvironmentType environmentType, DamageType damageType)
        {
            return _finalDamageStrategy.CalculateDamage(_attacker, _defender, environmentType, damageType);
        }
    }
}
