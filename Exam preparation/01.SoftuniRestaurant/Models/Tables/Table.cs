using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        //•	FoodOrders – collection of foods accessible only by the base class.
        //•	DrinkOrders – collection of drinks accessible only by the base class. 
        //•	TableNumber – int the table number 
        //•	Capacity – int the table capacity(capacity can’t be less than zero.In these cases, throw an ArgumentException with message "Capacity has to be greater than 0")
        //•	NumberOfPeople – int the count of people who want a table(number of people cannot be less or equal to 0. In these cases, throw an ArgumentException with message "Cannot place zero or less people!")
        //•	PricePerPerson – decimal the price per person for the table
        //•	IsReserved – bool returns true if the table is reserved
        //•	Price – calculated property, which calculates the price for all people

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
        }
        public int TableNumber { get; private set; }

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

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; set; }

        public decimal Price => this.PricePerPerson * this.numberOfPeople;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal totalSumFoodAndDrinkPrice = this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price);
            decimal totalSum = totalSumFoodAndDrinkPrice + Price;
            Clear();
            return totalSum;
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");

            if (this.PricePerPerson == 2.50M)
            {
                sb.AppendLine("Type: InsideTable");
            }
            else
            {
                sb.AppendLine("Type: OutsideTable");
            }
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                sb.AppendLine($"{string.Join(Environment.NewLine, this.foodOrders)}");
            }

            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                sb.AppendLine($"{string.Join(Environment.NewLine, this.drinkOrders)}");
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            if (this.PricePerPerson == 2.50M)
            {
                sb.AppendLine("Type: InsideTable");
            }
            else
            {
                sb.AppendLine("Type: OutsideTable");
            }
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}