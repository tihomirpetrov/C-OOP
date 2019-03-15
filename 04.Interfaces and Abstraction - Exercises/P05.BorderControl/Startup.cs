namespace P05.BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<IIdentifiable> allEntries = new List<IIdentifiable>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    long id = long.Parse(input[2]);

                    allEntries.Add(new Citizen(name, age, id));
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    long id = long.Parse(input[1]);

                    allEntries.Add(new Robot(model, id));
                }
            }


        }
    }
}