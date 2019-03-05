namespace P06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballTeam
    {
        private string name;
        private List<Player> players;

        public FootballTeam(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }
            int rating = (int)Math.Round(this.players.Select(x =>x.Skill()).Sum() / this.players.Count * 1.0);

            return rating;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            bool playerExist = this.players.Any(x => x.Name == playerName);
            if (!playerExist)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Player player = this.players.Where(x => x.Name == playerName).FirstOrDefault();

            this.players.Remove(player);
        }
    }
}