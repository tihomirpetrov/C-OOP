namespace P05.GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Bag
    {
        private List<Item> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            bag = new List<Item>();
        }

        public long GoldItemsValue
        {
            get
            {
                return bag.Where(i => i is GoldItem).Sum(i => i.Value);
            }
        }
        public long CashItemsValue
        {
            get
            {
                return bag.Where(i => i is GoldItem).Sum(i => i.Value);
            }
        }

        public long GemItemsValue
        {
            get
            {
                return bag.Where(i => i is GemItem).Sum(i => i.Value);
            }
        }

        public void AddGoldItem(GoldItem item)
        {
            if (capacity >= current + item.Value)
            {
                var goldItems = GetGoldItems();
                if (goldItems.Any(gi => gi.Key == item.Key))
                {
                    goldItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddGemItem(GemItem item)
        {
            if (capacity >= current + item.Value && GoldItemsValue >= GemItemsValue + item.Value) 
            {
                var gemItems = GetGemItems();
                if (gemItems.Any(gi => gi.Key == item.Key))
                {
                    gemItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddCashItem(CashItem item)
        {
            if (capacity >= current + item.Value && GemItemsValue >= CashItemsValue + item.Value)
            {
                var cashItems = GetCashItems();
                if (cashItems.Any(gi => gi.Key == item.Key))
                {
                    cashItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public List<Item> GetCashItems()
        {
            return bag.Where(i => i is CashItem).ToList();
        }

        public List<Item> GetGoldItems()
        {
            return bag.Where(i => i is GoldItem).ToList();
        }

        public List<Item> GetGemItems()
        {
            return bag.Where(i => i is GemItem).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var dictionary = bag.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in dictionary)
            {
                if (kvp.Key == "CashItem")
                {
                    sb.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "GemItem")
                {
                    sb.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "GoldItem")
                {
                    sb.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    sb.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}