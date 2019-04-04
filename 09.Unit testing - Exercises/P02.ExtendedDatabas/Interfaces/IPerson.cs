namespace P02.ExtendedDatabase.Interfaces
{
    public interface IPerson : IIdentifiable
    {
        string Username { get; }
    }
}