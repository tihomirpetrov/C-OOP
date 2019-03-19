namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    using P03.WildFarm.Models.Foods;
    using System;
    using System.Collections.Generic;
    public class Tiger : Feline
    {
        private const double GainValue = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }

        private void BaseEat(Food food, List<string> list, object gainValue)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}