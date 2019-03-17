namespace P08.MilitaryElite
{
    public class Mission
    {
        private string name;
        private string state;
        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name { get; set; }


        public string State
        {
            get
            {
                return this.State;
            }

            set
            {
                if (value == "inProgress" || value == "finished")
                {
                    this.state = value;
                }
            }
        }

        public void CorectState(string state)
        {
            this.State = state;
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (this.State == "inProgress")
            {
                result = $"Code Name: {this.Name} State: {this.State}";
            }

            return result.TrimEnd();
        }
    }
}
