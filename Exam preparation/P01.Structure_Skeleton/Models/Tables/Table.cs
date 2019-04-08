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
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();
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
            set
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
              
        public decimal GetBill()
        {
            decimal totalFoodPrice = this.FoodOrders.Sum(x => x.Price);
            decimal totalDrinkPrice = this.DrinkOrders.Sum(x => x.Price);
            return totalFoodPrice + totalDrinkPrice + Price;
        }

        public List<IFood> FoodOrders
        {
            get
            {
                return foodOrders;
            }
            set
            {
                this.foodOrders = value;
            }
        }

        public List<IDrink> DrinkOrders
        {
            get
            {
                return drinkOrders;
            }
            set
            {
                this.drinkOrders = value;
            }
        }

        public void Clear()
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
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
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
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

            if (FoodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {FoodOrders.Count}");

                foreach (var foodItem in FoodOrders)
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
                sb.AppendLine($"Drink orders: {DrinkOrders.Count}");

                foreach (var drinkItem in DrinkOrders)
                {
                    sb.AppendLine(drinkItem.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }
    }
}