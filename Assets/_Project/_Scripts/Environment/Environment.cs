using System.Collections.Generic;
using Task_Player;
using UnityEngine;


public abstract class Environment
{
    public abstract EnvironmentType Type { get; }

    public abstract Player ApplyEffect(Player player);
    public abstract List<Damage> ApplyEffect(Damage damage);

}
