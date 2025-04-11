using System;
using System.Collections.Generic;

namespace Task_Environment
{
    public enum EnvironmentType
    { Desert, Mountains, Forest, Hills }

    public class EnvironmentFactory : FactoryBase<EnvironmentType, Environment>
    {
        public EnvironmentFactory()
        {
            Register(EnvironmentType.Desert, _ => new EnvironmentDesert());
            Register(EnvironmentType.Forest, _ => new EnvironmentForest());
            Register(EnvironmentType.Mountains, _ => new EnvironmentMountains());
            Register(EnvironmentType.Hills, _ => new EnvironmentHills());
        }
    }
}