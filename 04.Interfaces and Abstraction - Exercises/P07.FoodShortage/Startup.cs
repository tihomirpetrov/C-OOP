namespace P07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<IBuyer> allEntries = new List<IBuyer>();

            int peoples = int.Parse(Console.ReadLine());

            for (int i = 0; i < peoples; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    allEntries.Add(new Citizen(name, age, id, birthdate));
                }

                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    allEntries.Add(new Rebel(name, age, group));
                }
            }

            string input2 = Console.ReadLine();

            while (input2 != "End")
            {
                var buyer = allEntries.SingleOrDefault(x => x.Name == input2);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                input2 = Console.ReadLine();
            }

            Console.WriteLine(allEntries.Sum(x =>x.Food));            
        }
    }
}