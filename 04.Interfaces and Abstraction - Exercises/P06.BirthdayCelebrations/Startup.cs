﻿namespace P06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<IIdentifiable> allEntries = new List<IIdentifiable>();
            //List<Robot> robots = new List<Robot>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];

                    allEntries.Add(new Citizen(name, age, id, birthdate));
                }
                //else if (input[0] == "Robot")
                //{
                //    string model = input[1];
                //    string id = input[2];

                //    robots.Add(new Robot(model, id));
                //}
                else if (input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];
                }

                input = Console.ReadLine().Split();
            }

            string birthYear = Console.ReadLine();

            allEntries.Where(x => x.Birthdate.EndsWith(birthYear)).Select(x => x.Birthdate).ToList().ForEach(Console.WriteLine);
        }
    }
}