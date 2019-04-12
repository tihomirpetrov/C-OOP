namespace DungeonsAndCodeWizards.Models.Bags
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private int capacity;
        private int load;
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = 100;
            this.Load = load;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }
        public int Load
        {
            get
            {
                return this.load;
            }
            private set
            {
                var itemsSum = this.items.Sum(x => x.Weight);
                this.load = itemsSum;
            }
        }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }
        public void AddItem(Item item)
        {
            var itemsSum = this.items.Sum(x => x.Weight);


            if (this.load + itemsSum > capacity)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            var itemName = this.items.Any(x => x.GetType().Name == name);
            var item = this.items.First(x => x.GetType().Name == name);

            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!itemName)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            this.items.Remove(item);

            return item;
        }
    }
}