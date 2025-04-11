using System.Collections.Generic;
using System;
using Task_Player;
using UnityEngine;

public class EnvironmentFactory
{
    private readonly Dictionary<EnvironmentType, Func<Environment>> _registry = new();

    public EnvironmentFactory()
    {
        // Register all weapon types
        _registry[EnvironmentType.Desert] = () => new EnvironmentDesert();
        _registry[EnvironmentType.Forest] = () => new EnvironmentForest();
        _registry[EnvironmentType.Mountains] = () => new EnvironmentMountains();
        _registry[EnvironmentType.Hills] = () => new EnvironmentHills();
    }

    public Environment Create(EnvironmentType type)
    {
        if (_registry.TryGetValue(type, out var constructor))
        {
            return constructor();
        }

        throw new ArgumentException($"Environment type '{type}' not registered.");
    }
}