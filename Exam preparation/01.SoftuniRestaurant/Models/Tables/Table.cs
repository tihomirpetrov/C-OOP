using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders = new List<IFood>();
        private List<IDrink> drinkOrders = new List<IDrink>();
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved = false;
        private decimal price;

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
        }

        public List<IFood> FoodOrders { get; private set; }

        public List<IDrink> DrinkOrders { get; private set; }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
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
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get; private set;
        }

        public bool IsReserved
        {
            get
            {
                return this.IsReserved;
            }
            private set
            {
                this.IsReserved = true;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                this.price = value;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public decimal GetBill()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTableInfo()
        {
            throw new NotImplementedException();
        }

        public void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        public void OrderFood(IFood food)
        {
            throw new NotImplementedException();
        }

        public void Reserve(int numberOfPeople)
        {
            
        }
        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }
    }
}