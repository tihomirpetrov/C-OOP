namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    public abstract class Item
    {
        private int weight;

        public Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                this.weight = value;
            }
        }

        public virtual void AffectCharacter(Character character)
        {
            if (IsAlive = false)
            {
                throw new ArgumentException("Must be alive to perform this action!");
            }
        }
    }
}
