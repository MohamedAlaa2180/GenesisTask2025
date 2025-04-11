using Task_Player;

public abstract class Resistance
{
    public abstract DamageType Type { get; }
    public float ResistanceAmount { get; set; }

    protected Resistance(float amount)
    {
        ResistanceAmount = amount;
    }

    public void IncreaseByValue(float value) => ResistanceAmount += value;

    public void IncreaseByRatio(float value) => ResistanceAmount += ResistanceAmount * value;

    public void DecreaseByValue(float value) => ResistanceAmount -= value;

    public void DecreaseByRatio(float value) => ResistanceAmount -= ResistanceAmount * value;

    public void SetResistance(float value) => ResistanceAmount = value;

    public float GetResistance() => ResistanceAmount / (ResistanceAmount + 100f);

}