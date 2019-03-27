namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Contracts;
    using P07.InfernoInfinity.Models.Enums;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(int minDamage, int maxDamage, WeaponRarity rarity, string name)
        {
            this.Rarity = rarity;
            this.MinDamage = minDamage * (int)this.Rarity;
            this.MaxDamage = maxDamage * (int)this.Rarity;
            this.Name = name;
        }

        public string Name { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public IGem[] Gems { get; private set; }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public WeaponRarity Rarity { get; private set; }

        public void DegradeWeapon(IGem gem)
        {
            this.Strength += gem.StreangthModifier;
            this.Agility += gem.AgilityModifier;
            this.Vitality += gem.VitalityModifier;

            this.MinDamage += (gem.StreangthModifier * 2) + gem.AgilityModifier;
            this.MaxDamage += (gem.StreangthModifier * 3) + (gem.AgilityModifier * 4);
        }

        public void Modify(IGem gem)
        {
            this.MinDamage -= (gem.StreangthModifier * 2) + gem.AgilityModifier;
            this.MaxDamage -= (gem.StreangthModifier * 3) + (gem.AgilityModifier * 4);

            this.Strength -= gem.StreangthModifier;
            this.Agility -= gem.AgilityModifier;
            this.Vitality -= gem.VitalityModifier;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}