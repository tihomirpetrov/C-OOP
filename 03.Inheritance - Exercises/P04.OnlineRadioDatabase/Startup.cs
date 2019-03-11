namespace P04.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var songs = GetSongs();
            PrintPlaylistSummary(songs);
        }

        private static void PrintPlaylistSummary(List<Song> playlist)
        {
            Console.WriteLine($"Songs added: {playlist.Count}");

            int totalSeconds = playlist.Select(s => s.SongSeconds).Sum();
            int secondsToMinutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            int totalMinutes = playlist.Select(s => s.SongMinutes).Sum() + secondsToMinutes;
            int minutesToHours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            int hours = minutesToHours;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }

        private static List<Song> GetSongs()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>(numberOfSongs);

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputLine = Console.ReadLine().Split(';');

                try
                {
                    int songTime = inputLine[2].IndexOf(':');

                    string artist = inputLine[0];
                    string songName = inputLine[1];
                    int songMinutes = int.Parse(inputLine[2].Substring(0, songTime));
                    int songSeconds = int.Parse(inputLine[2].Substring(songTime + 1));

                    songs.Add(new Song(artist, songName, songMinutes, songSeconds));
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return songs;
        }
    }
}