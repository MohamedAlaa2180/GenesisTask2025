using Task_Environment;
using Task_Player;

/// <summary>
/// Defines a strategy interface for calculating damage between two players.
/// Supports optional environment and damage type parameters for context-sensitive calculations.
/// </summary>
public interface IDamageCalculationStrategy
{
    /// <summary>
    /// Calculates the damage dealt from <paramref name="attacker"/> to <paramref name="defender"/>.
    /// </summary>
    /// <param name="attacker">The player initiating the attack.</param>
    /// <param name="defender">The player receiving the damage.</param>
    /// <param name="environmentType">
    /// The environment in which the attack occurs.
    /// Default is <see cref="EnvironmentType.Desert"/>.
    /// </param>
    /// <param name="damageType">
    /// The type of damage being dealt (Physical, Fire, Ice, Poison).
    /// Default is <see cref="DamageType.Fire"/>.
    /// </param>
    /// <returns>
    /// A <see cref="float"/> representing the amount of damage after applying all relevant factors.
    /// </returns>
    float CalculateDamage(
        Player attacker,
        Player defender,
        EnvironmentType environmentType = EnvironmentType.Desert,
        DamageType damageType = DamageType.Fire);
}