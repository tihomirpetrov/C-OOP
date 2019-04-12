namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Contracts;
    using System;

    public class Warrior : Character, IAttackable
    {
        private const int baseHealthWarrior = 100;
        private const int baseArmorWarrior = 50;
        private const int abilityPointsWarrior = 40;
        private static Satchel warriorBag = new Satchel();
        private static Faction faction;
        
        public Warrior(string name, Faction faction)
            : base(name, baseHealthWarrior, baseArmorWarrior, abilityPointsWarrior, warriorBag, faction)
        {
        }
        
        public void Attack(Character character)
        {
            if (character.IsAlive && this.IsAlive)
            {
                if (character.Name == this.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                else if(Warrior.faction.Equals(faction))
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {faction} faction!");
                }
                else
                {
                    character.TakeDamage(abilityPointsWarrior);
                }
            }
        }
    }
}