using System.Collections.Generic;
using Task_Player;

namespace Task_Environment
{
    /// <summary>
    /// Abstract base class for different types of environments that affect the player and damage types.
    /// Each derived class should define specific effects on players and damages based on the environment type.
    /// </summary>
    public abstract class Environment
    {
        /// <summary>
        /// Gets the type of environment (e.g., Desert, Forest, etc.).
        /// </summary>
        public abstract EnvironmentType Type { get; }

        /// <summary>
        /// Applies specific environmental effects to the player.
        /// This could modify the player's stats (e.g., health, resistances) based on the environment.
        /// </summary>
        /// <param name="player">The player affected by the environment.</param>
        /// <returns>The modified player after applying environmental effects.</returns>
        public abstract Player ApplyEffectOnPlayer(Player player);

        /// <summary>
        /// Applies specific environmental effects on a damage type.
        /// This method adjusts the damage values based on the environmental factors (e.g., fire damage in a hot environment).
        /// </summary>
        /// <param name="damage">The damage being affected by the environment.</param>
        /// <returns>A list of modified damages after applying the environment's effect.</returns>
        public abstract List<Damage> ApplyEffectOnDamageType(Damage damage);
    }
}
