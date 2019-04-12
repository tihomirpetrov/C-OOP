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
        private IReadOnlyCollection<Item> items;

        public Bag(int capacity)
        {
            this.capacity = 100;
            this.Load = load;
            this.Items = new List<Item>();
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

        public List<Item> Items { get; set; }
        public void AddItem(Item item)
        {
            var itemsSum = this.items.Sum(x => x.Weight);


            if (this.load + itemsSum > capacity)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!Items.Contains(name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Items.Remove(name);
        }
    }
}