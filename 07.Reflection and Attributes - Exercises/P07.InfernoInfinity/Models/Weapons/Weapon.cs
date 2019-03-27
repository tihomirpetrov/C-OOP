namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Contracts;
    public class Weapon : IWeapon
    {
        public Weapon(string name, int minDamage, int maxDamage)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }

        public string Name { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }
    }
}