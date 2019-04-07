namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            var typeOfFood = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x =>x.Name == type);
            var food = (IFood)Activator.CreateInstance(typeOfFood, new object[] { name, price });

            this.menu.Add(food);
            return $"Added {food.Name} ({typeOfFood.Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var typeOfDrink = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);
            var drink = (IDrink)Activator.CreateInstance(typeOfDrink, new object[] { name, servingSize, brand });

            this.drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var typeOftable = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);
            var table = (ITable)Activator.CreateInstance(typeOftable, new object[] { tableNumber, capacity });

            this.tables.Add(table);
            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            throw new NotImplementedException();
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            throw new NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            throw new NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public string GetFreeTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
