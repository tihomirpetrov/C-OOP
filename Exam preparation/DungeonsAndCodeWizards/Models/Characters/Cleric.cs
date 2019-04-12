namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Contracts;
    using System;

    public class Cleric : Character, IHealable
    {
        private const int baseHealthCleric = 50;
        private const int baseArmorCleric = 25;
        private const int abilityPointsCleric = 40;
        private static Backpack clericBag = new Backpack();
        private static Faction faction;

        public Cleric(string name, Faction faction) 
            : base(name, baseHealthCleric, baseArmorCleric, abilityPointsCleric, clericBag, faction)
        {
        }

        public void Heal(Character character)
        {
            if (character.IsAlive && this.IsAlive)
            {
                if (character.Name == this.Name)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }
                else
                {
                    character.Health += abilityPointsCleric;
                }
            }
        }
    }
}