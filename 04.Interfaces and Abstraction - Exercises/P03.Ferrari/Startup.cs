namespace Ferrari
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Ferrari ferrari = new Ferrari(input);

            Console.WriteLine(ferrari.ToString());
        }
    }
}