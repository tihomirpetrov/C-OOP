using System;

namespace P04.OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string songTime;

        public Song(string artistName, string songName, string songTime)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongTime = songTime;
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }
            set
            {
                if (value.Length < 3 && value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.artistName = value;
            }
        }
        public string SongName
        {
            get
            {
                return this.songName;
            }
            set
            {
                if (value.Length < 3 && value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.songName = value;
            }
        }
        public string SongTime
        {
            get
            {
                return this.songTime;
            }
            set
            {
                if (value[0] < 0 && value[0] > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                if (value[1] < 0 && value[1] > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                this.songTime = value;
            }
        }
    }
}