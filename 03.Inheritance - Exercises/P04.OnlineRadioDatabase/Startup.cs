namespace P04.OnlineRadioDatabase
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputLine = Console.ReadLine().Split(";");
                string artist = inputLine[0];
                string songName = inputLine[1];
                string songTime = inputLine[2];
            }

            try
            {
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}