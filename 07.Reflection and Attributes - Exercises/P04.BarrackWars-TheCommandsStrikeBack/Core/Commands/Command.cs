namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
   
    public abstract class Command : IExecutable
    {
        private string[] data;
       
        protected Command(string[] data)
        {
            this.data = data;            
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }

        public abstract string Execute();
    }
}