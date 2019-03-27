namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;

    public class ReportCommand : Command
    {
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }
}