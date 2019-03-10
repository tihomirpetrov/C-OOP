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
                string[] songTime = inputLine[2].Split(":");
                int songMinutes = int.Parse(songTime[0]);
                int songSeconds = int.Parse(songTime[1]);

                Song song = new Song(artist, songName, songMinutes, songSeconds);
            }

            try
            {
                Console.WriteLine(song);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}