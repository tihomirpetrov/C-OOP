namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

        public int TableNumber { get; set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; set; }

        public bool IsReserved { get; set; }

        public decimal Price
        {
            get
            {
                return this.NumberOfPeople * this.PricePerPerson;
            }            
        }

        public void Reserve(int numberOfPeople)
        {
            if (this.Capacity >= numberOfPeople)
            {
                this.NumberOfPeople = numberOfPeople;
                this.IsReserved = true;
            }
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal totalSum = this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price);
            return totalSum;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            if (this.PricePerPerson == 2.50M)
            {
                sb.AppendLine($"Type: InsideTable");
            }
            else if (this.PricePerPerson == 3.50M)
            {
                sb.AppendLine($"Type: OutsideTable");
            }
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per person: {this.PricePerPerson}");

            return sb.ToString();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            if (this.PricePerPerson == 2.50M)
            {
                sb.AppendLine($"Type: InsideTable");
            }
            else if (this.PricePerPerson == 3.50M)
            {
                sb.AppendLine($"Type: OutsideTable");
            }
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (var foodItem in this.foodOrders)
                {
                    sb.AppendLine(foodItem.ToString());
                }
            }

            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (var drinkItem in this.drinkOrders)
                {
                    sb.AppendLine(drinkItem.ToString());
                }
            }

            return sb.ToString();
        }        
    }
}