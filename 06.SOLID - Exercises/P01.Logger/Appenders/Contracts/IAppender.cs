namespace P01.Logger.Appenders.Contracts
{
    using P01.Logger.Loggers.Enums;
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}