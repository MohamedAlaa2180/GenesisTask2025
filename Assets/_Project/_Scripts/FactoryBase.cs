using System;
using System.Collections.Generic;

public abstract class FactoryBase<TKey, TBase>
{
    private readonly Dictionary<TKey, Func<object[], TBase>> _registry = new();

    protected void Register(TKey key, Func<object[], TBase> constructor)
    {
        _registry[key] = constructor;
    }

    public TBase Create(TKey key, params object[] args)
    {
        if (_registry.TryGetValue(key, out var constructor))
        {
            return constructor(args);
        }

        throw new ArgumentException($"Type '{key}' is not registered in the factory.");
    }
}