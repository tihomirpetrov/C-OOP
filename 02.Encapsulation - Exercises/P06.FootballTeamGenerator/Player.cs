namespace P06.FootballTeamGenerator
{
    using System;
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                this.ValidateParameter(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            set
            {
                this.ValidateParameter(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            set
            {
                this.ValidateParameter(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            set
            {
                this.ValidateParameter(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            set
            {
                this.ValidateParameter(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        private void ValidateParameter(int value, string parameterName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{parameterName} should be between 0 and 100.");
            }
        }

        public int Skill()
        {
            int skill = (int)Math.Round(this.endurance + this.sprint + this.dribble + this.passing + this.shooting / 5.0);
            return skill;
        }
    }
}