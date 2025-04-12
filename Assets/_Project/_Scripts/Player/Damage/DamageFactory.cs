namespace Task_Player
{
    public enum DamageType
    { Physical, Fire, Ice, Poison }

    public class DamageFactory : FactoryBase<DamageType, Damage>
    {
        public DamageFactory()
        {
            Register(DamageType.Fire, args => new DamageFire((float)args[0]));
            Register(DamageType.Ice, args => new DamageIce((float)args[0]));
            Register(DamageType.Physical, args => new DamagePhysical((float)args[0]));
            Register(DamageType.Poison, args => new DamagePoison((float)args[0]));
        }
    }
}