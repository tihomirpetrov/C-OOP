namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Contracts;
    using P07.InfernoInfinity.Models.Enums;
    public class Sword : Weapon
    {
        public Sword(WeaponRarity rarity, string name) : base(4, 6, rarity, name)
        {
            this.Gems = new IGem[3];
        }
    }
}