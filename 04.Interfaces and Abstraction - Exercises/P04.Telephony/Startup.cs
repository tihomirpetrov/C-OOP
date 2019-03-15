namespace Telephony
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            
            Smartphone smartphone = new Smartphone(phoneNumbers, urls);
            List<ICall> devices = new List<ICall>();
            devices.Add(smartphone);

            foreach (var item in devices)
            {
                Console.WriteLine(item.CallOtherNumbers());
            }

            //Console.WriteLine(smartphone);

        }
    }
}