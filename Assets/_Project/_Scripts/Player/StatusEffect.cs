namespace Task_Player
{
    public class StatusEffect
    {
        public string Name { get; set; }
        public float DamageMultiplier { get; set; }

        public StatusEffect(string name, float damageMultiplier)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
        }

        public void ModifyMultiplierByRatio(float value) => DamageMultiplier += DamageMultiplier * value;

        public float GetEffectValue => DamageMultiplier - 1;
    }
}