using System.Collections.Generic;
using System;
using Task_Player;
using UnityEngine;
using System.Linq;

public static class DamageFactory
{
    public static Damage Create(DamageType type, float amount)
    {
        switch(type)
        {
            case DamageType.Physical:
                return new DamagePhysical(amount);
            case DamageType.Poison:
                return new DamagePoison(amount);
            case DamageType.Fire:
                return new DamageFire(amount);
            case DamageType.Ice:
                return new DamageIce(amount);
            default:
                throw new ArgumentException($"No Damage registered for {type}");
        }
    }
}
