namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private bool isAlive;
        private double restHealMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.IsAlive = isAlive;
            this.health = health;
            this.baseHealth = 100;
            this.armor = armor;
            this.baseArmor = 100;
            this.abilityPoints = abilityPoints;
            this.Bag = bag;
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

        public double BaseHealth { get; private set; }
        public double Health { get; set; }
        public double BaseArmor { get; private set; }
        public double Armor { get; set; }
        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            set
            {
                isAlive = true;
            }
        }
        public double AbilityPoints { get; set; }

        public Bag Bag { get; }
        public enum Faction { CSharp, Java };

        public void TakeDamage(double hitPoints)
        {
            if (this.isAlive)
            {
                if (hitPoints - this.armor < 0)
                {
                    double leftHitPoints = hitPoints - this.armor;
                    this.armor -= hitPoints - leftHitPoints;
                    if (this.health - leftHitPoints > 0)
                    {
                        this.health -= leftHitPoints;
                    }
                    else
                    {
                        this.isAlive = false;
                    }
                }
                else
                {
                    this.armor -= hitPoints;
                }
            }
        }

        public void Rest()
        {
            if (this.isAlive)
            {
                this.health = health + (100 * restHealMultiplier);
            }
        }

        public void UseItem(Item item)
        {
            if (this.isAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.isAlive && character.isAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.isAlive && character.isAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.isAlive)
            {
                this.Bag.AddItem(item);
            }
        }
    }
}