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

            var totalSeconds = playlist.Select(s => s.SongSeconds).Sum();
            var secondsToMinutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;

            var totalMinutes = playlist.Select(s => s.SongMinutes).Sum() + secondsToMinutes;
            var minutesToHours = totalMinutes / 60;
            var minutes = totalMinutes % 60;

            var hours = minutesToHours;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }

        private static List<Song> GetSongs()
        {
            var numberOfSongs = int.Parse(Console.ReadLine());
            var songs = new List<Song>(numberOfSongs);

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] inputLine = Console.ReadLine().Split(';');

                try
                {
                    int songTime = inputLine[2].IndexOf(':');


                    string artist = inputLine[0];
                    string songName = inputLine[1];
                    int songMinutes = int.Parse
                        (inputLine[2].Substring(0, songTime));
                    int songSeconds = int.Parse
                        (inputLine[2].Substring(songTime + 1));

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