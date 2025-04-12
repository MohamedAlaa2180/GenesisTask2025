using Task_Environment;
using Task_Player;
using UnityEngine;

/// <summary>
/// Abstract class for implementing the Chain of Responsibility pattern in damage calculation strategies.
/// Derived classes should define how damage is calculated, using a chain of damage handlers to apply specific effects.
/// </summary>
public abstract class ChainedDamageCalculationStrategy : IDamageCalculationStrategy
{
    /// <summary>
    /// The first handler in the chain of responsibility.
    /// </summary>
    protected DamageHandler _chainHead;

    /// <summary>
    /// Calculates the damage from an attacker to a defender, applying a chain of damage handlers for various effects.
    /// This method should be implemented by subclasses to define specific damage calculation logic.
    /// </summary>
    /// <param name="attacker">The player initiating the attack.</param>
    /// <param name="defender">The player receiving the damage.</param>
    /// <param name="environmentType">The environment where the damage takes place.</param>
    /// <param name="damageType">The type of damage being dealt (e.g., physical, fire, etc.).</param>
    /// <returns>The calculated damage after applying all relevant factors.</returns>
    public abstract float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType, DamageType damageType);
}
