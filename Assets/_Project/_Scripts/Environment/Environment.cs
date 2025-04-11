using System.Collections.Generic;
using Task_Player;

namespace Task_Environment
{
    public abstract class Environment
    {
        public abstract EnvironmentType Type { get; }

        public abstract Player ApplyEffectOnPlayer(Player player);

        public abstract float ApplyEffectOnDamageValue(float damage);

        public abstract List<Damage> ApplyEffectOnDamageType(Damage damage);
    }
}