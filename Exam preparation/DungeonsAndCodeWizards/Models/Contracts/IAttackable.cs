namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Characters;
    public interface IAttackable
    {
        void Attack(Character character);
    }
}