namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private List<Bags> bag;
        private enum faction { CSharp, Java};
        private bool isAlive;
        private double restHealMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.isAlive = true;
            this.health = health;
            this.armor = armor;
            this.abilityPoints = abilityPoints;
            this.bag = new List<Bags>();            
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {

        }

        public void Rest()
        {

        }

        public void UseItem(Item item)
        {

        }

        public void UseItemOn(Item item, Character character)
        {

        }

        public void GiveCharacterItem(Item item, Character character)
        {

        }

        public void ReceiveItem(Item item)
        {

        }
    }
}
