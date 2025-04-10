using System.Collections.Generic;
using Task_Player;
using UnityEngine;

public class EnvironmentForest : Environment
{
    public override EnvironmentType Type => EnvironmentType.Forest;
    public override Player ApplyEffect(Player player)
    {
        // Implement the effect of the desert environment on the player
        return player;
    }

    public override List<Damage> ApplyEffect(Damage damage)
    {
        throw new System.NotImplementedException();
    }
}
