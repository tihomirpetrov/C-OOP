namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Contracts;
    using P07.InfernoInfinity.Models.Enums;
    public class Axe : Weapon
    {
        public Axe(WeaponRarity rarity, string name) : base(5, 10, rarity, name)
        {
            this.Gems = new IGem[4];
        }
    }
}