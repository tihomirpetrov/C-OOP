namespace P07.InfernoInfinity.Weapons
{
    using P07.InfernoInfinity.Models.Enums;
    public class Knife : Weapon
    {
        public Knife(int minDamage, int maxDamage, WeaponRarity rarity, string name) : base(minDamage, maxDamage, rarity, name)
        {
        }
    }
}