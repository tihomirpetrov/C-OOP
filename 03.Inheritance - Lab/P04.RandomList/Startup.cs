namespace CustomRandomList
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var randomList = new RandomList();
            randomList.Add("Test");
            randomList.Add("Ivan");
            randomList.Add("Pesho");

            Console.WriteLine(randomList.RandomString());
        }
    }
}