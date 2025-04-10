using Task_Player;
using UnityEngine;

public static class EnvironmentFactory
{
    public static Environment Create(EnvironmentType type)
    {
        switch (type)
        {
            case EnvironmentType.Forest:
                return new EnvironmentForest();

            case EnvironmentType.Desert:
                return new EnvironmentDesert();

            case EnvironmentType.Hills:
                return new EnvironmentHills();

            case EnvironmentType.Mountains:
                return new EnvironmentMountains();

            default:
                throw new System.ArgumentException($"No Environment registered for {type}");
        }
    }
}