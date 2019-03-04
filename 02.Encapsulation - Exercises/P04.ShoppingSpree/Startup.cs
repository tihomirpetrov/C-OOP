namespace P04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                string[] tokens = item.Split('=');
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                try
                {
                    persons.Add(new Person(name, money));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                string[] tokens = item.Split('=');
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                input = command.Split();
                string personName = input[0];
                string productName = input[1];
                Person person = persons.Where(x => x.Name == personName).First();
                Product product = products.Where(x => x.Name == productName).First();

                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProductToBag(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                command = Console.ReadLine();
            }


            foreach (Person person in persons)
            {
                if (person.SeeBag().Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.SeeBag().Select(x =>x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}