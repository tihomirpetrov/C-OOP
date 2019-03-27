namespace P07.InfernoInfinity.Contracts
{
    using P07.InfernoInfinity.Models.Enums;
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        IGem[] Gems { get; }
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        WeaponRarity Rarity { get; set; }

        void Modify(IGem gem);
        void DegradeWeapon(IGem gem);
    }
}