namespace P05.Mordor_sCruelPlan
{
    using P05.Mordor_sCruelPlan.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Food> foodsEaten = new List<Food>();
            string[] foods = Console.ReadLine().Split();

            foreach (var food in foods)
            {
                switch (food.ToLower())
                {
                    case "apple":
                        foodsEaten.Add(new Apple());
                        break;
                    case "cram":
                        foodsEaten.Add(new Cram());
                        break;
                    case "honeycake":
                        foodsEaten.Add(new HoneyCake());
                        break;
                    case "lembas":
                        foodsEaten.Add(new Lembas());
                        break;
                    case "melon":
                        foodsEaten.Add(new Melon());
                        break;
                    case "mushrooms":
                        foodsEaten.Add(new Mushrooms());
                        break;
                    default:
                        foodsEaten.Add(null);
                        break;
                }
            }

            int happinessFood = foodsEaten.Where(c=>c != null).Select(x =>x == null ? -1: x.Happiness).Sum();

            Console.WriteLine(happinessFood);

            if (happinessFood < -5)
            {

            }
        }
    }
}