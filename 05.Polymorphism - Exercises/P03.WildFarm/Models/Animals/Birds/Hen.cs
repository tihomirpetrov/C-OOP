﻿namespace P03.WildFarm.Models.Animals.Birds
{
    using P03.WildFarm.Models.Foods;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double GainValue = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        
        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Vegetable), nameof(Fruit), nameof(Seeds), nameof(Meat) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}