namespace P08.MilitaryElite
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Army army = new Army();

                string typeSoldier = parts[0];
                int id = int.Parse(parts[1]);
                string firstName = parts[2];
                string lastName = parts[3];
                int salary;

                switch (typeSoldier)
                {
                    
                    case "Private":
                        salary = int.Parse(parts[4]);
                        Private currentPrivate = new Private(id, firstName, lastName, salary);
                        army.AddSoldier(currentPrivate);
                        break;

                    case "LieutenantGeneral":
                        salary = int.Parse(parts[4]);
                        int[] ids = new int[parts.Length - 4];
                        for (int i = 0; i < ids.Length; i++)
                        {
                            ids[i] = int.Parse(parts[i + 3]);
                        }
                        HashSet<Private> privates = army.GetPrivates(ids);
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        break;

                    case "":
                        break;
                }
            }
        }
    }
}