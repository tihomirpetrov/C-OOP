namespace P01.Logger.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, string reportLevel, string message);
    }
}
