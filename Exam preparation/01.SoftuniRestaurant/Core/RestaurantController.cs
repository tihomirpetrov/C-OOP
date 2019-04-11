namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.income = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = null;

            switch (type)
            {
                case "Dessert":
                    food = new Dessert(name, price);
                    break;
                case "Salad":
                    food = new Salad(name, price);
                    break;
                case "Soup":
                    food = new Soup(name, price);
                    break;
                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;
                default: throw new ArgumentException($"Invalid food type {type}!");
            }

            this.menu.Add(food);
            return $"Added {food.Name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;
                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;
                case "Alcohol":
                    drink = new Alcohol(name, servingSize, brand);
                    break;
                default: throw new ArgumentException($"Invalid drink type {type}!");
            }

            this.drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default: throw new ArgumentException($"Invalid table type {type}!");
            }

            this.tables.Add(table);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var table in tables)
            {
                if (!table.IsReserved && table.Capacity >= numberOfPeople)
                {
                    table.IsReserved = true;
                    table.NumberOfPeople = numberOfPeople;
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }
            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            foreach (var table in tables)
            {
                if (tableNumber == table.TableNumber)
                {
                    foreach (var food in menu)
                    {
                        if (food.Name == foodName)
                        {
                            table.OrderFood(food);
                            return $"Table {tableNumber} ordered {foodName}";
                        }
                    }
                    return $"No {foodName} in the menu";
                }
            }
            return $"Could not find table with {tableNumber}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            foreach (var table in tables)
            {
                if (tableNumber == table.TableNumber)
                {
                    foreach (var drink in drinks)
                    {
                        if (drink.Name == drinkName)
                        {
                            table.OrderDrink(drink);
                            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                        }
                    }
                    return $"There is no {drinkName} {drinkBrand} available";
                }
            }
            return $"Could not find table with {tableNumber}";
        }

        public string LeaveTable(int tableNumber)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (table.TableNumber == tableNumber)
                {
                    sb.AppendLine($"Table: {tableNumber}");
                    decimal bill = table.GetBill();
                    sb.AppendLine($"Bill: {bill:F2}");
                    income += bill;
                    table.Clear();
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (!table.IsReserved)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (table.IsReserved)
                {
                    sb.AppendLine(table.GetOccupiedTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
