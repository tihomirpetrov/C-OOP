namespace P01.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);
        void Warning(string dateTime, string warningMessage);
        void Critical(string dateTime, string criticalMessage);
        void Fatal(string dateTime, string fatalMessage);        
        void Info(string dateTime, string infoMessage);
    }
}