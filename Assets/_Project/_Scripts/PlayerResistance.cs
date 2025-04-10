using System.Collections.Generic;
using Task_Player;

public class PlayerResistance
{
    public float PhysicalResistance { get; private set; }
    public float FireResistance { get; private set; }
    public float IceResistance { get; private set; }
    public float PoisonResistance { get; private set; }

    // Dictionary to map DamageType to corresponding resistance
    private Dictionary<DamageType, float> resistanceDict;
    public PlayerResistance(float physicalResistance = 0, float fireResistance = 0, float iceResistance = 0, float poisonResistance = 0)
    {
        PhysicalResistance = physicalResistance;
        FireResistance = fireResistance;
        IceResistance = iceResistance;
        PoisonResistance = poisonResistance;

        // Initialize the dictionary to map each DamageType to its corresponding resistance
        resistanceDict = new Dictionary<DamageType, float>
        {
            { DamageType.Physical, PhysicalResistance },
            { DamageType.Fire, FireResistance },
            { DamageType.Ice, IceResistance },
            { DamageType.Poison, PoisonResistance }
        };
    }

    public float GetResistance(DamageType damageType)
    {
        // Fetch the resistance value from the dictionary, or return 0 if the damage type is not found
        var resistanceBase = resistanceDict.TryGetValue(damageType, out var resistance) ? resistance : 0f;
        return resistanceBase / (resistanceBase + 100f);
    }
}