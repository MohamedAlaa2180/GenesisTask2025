namespace Task_Player
{
    public class StatusEffect
    {
        public string Name { get; set; }
        public float DamageMultiplier { get; set; }

        private float _originalDamageMultiplier;

        public StatusEffect(string name, float damageMultiplier)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
            _originalDamageMultiplier = damageMultiplier;
        }
        public StatusEffect Clone()
        {
            return new StatusEffect(this.Name, this.DamageMultiplier);
        }

        public void ModifyMultiplierByRatio(float value) => DamageMultiplier += DamageMultiplier * value;
        public void DisableEffect() => DamageMultiplier = 1f;
        public void EnableEffect() => DamageMultiplier = _originalDamageMultiplier;

        public float GetEffectValue => DamageMultiplier - 1;
    }
}