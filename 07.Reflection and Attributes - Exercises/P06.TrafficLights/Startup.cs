namespace P06.TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            TrafficLight[] trafficLights = new TrafficLight[input.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { input[i] });
            }

            int timesChange = int.Parse(Console.ReadLine());

            for (int i = 0; i < timesChange; i++)
            {
                List<string> result = new List<string>();

                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.UpdateSignal();

                    var field = typeof(TrafficLight).GetField("currentSignal", BindingFlags.NonPublic | BindingFlags.Instance);

                    result.Add(field.GetValue(trafficLight).ToString());
                }

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}