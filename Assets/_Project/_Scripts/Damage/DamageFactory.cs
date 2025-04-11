using System.Collections.Generic;
using System;
using Task_Player;
using UnityEngine;
using System.Linq;

public class DamageFactory
{
    private readonly Dictionary<DamageType, Func<float, Damage>> _registry = new();

    public DamageFactory()
    {
        // Register all weapon types
        _registry[DamageType.Fire] = amount => new DamageFire(amount);
        _registry[DamageType.Ice] = amount => new DamageIce(amount);
        _registry[DamageType.Physical] = amount => new DamagePhysical(amount);
        _registry[DamageType.Poison] = amount => new DamagePoison(amount);
    }

    public Damage Create(DamageType type, float amount)
    {
        if (_registry.TryGetValue(type, out var constructor))
        {
            return constructor(amount);
        }

        throw new ArgumentException($"Damage type '{type}' not registered.");
    }
}
