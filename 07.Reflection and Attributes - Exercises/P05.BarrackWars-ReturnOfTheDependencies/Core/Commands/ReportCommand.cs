namespace P05.BarrackWars_ReturnOfTheDependencies.Core.Commands
{
    using P05.BarrackWars_ReturnOfTheDependencies.Contracts;

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