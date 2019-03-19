﻿namespace P03.WildFarm.Models.Animals
{
    using P03.WildFarm.Models.Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void Eat();
        protected void BaseEat(Food food, List<string> eatableFood, double gainValue)
        {
            string typeFood = food.GetType().Name;

            if (!eatableFood.Contains(typeFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");                
            }
            else
            {
                this.Weight += food.Qunatity * gainValue;
                this.FoodEaten += food.Qunatity;
            }
        }
    }
}