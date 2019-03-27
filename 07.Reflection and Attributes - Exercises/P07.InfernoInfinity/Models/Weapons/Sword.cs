namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Models.Enums;
    public class Sword : Weapon
    {
        public Sword(int minDamage, int maxDamage, WeaponRarity rarity, string name) : base(minDamage, maxDamage, rarity, name)
        {
        }
    }
}