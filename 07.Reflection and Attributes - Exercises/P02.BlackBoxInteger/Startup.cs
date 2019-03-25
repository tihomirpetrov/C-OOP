namespace P02.BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);
            BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split("_");
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(instance, new object[] { value });
                int currentValue = (int)classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(instance);

                Console.WriteLine(currentValue);

                command = Console.ReadLine();
            }
        }
    }
}