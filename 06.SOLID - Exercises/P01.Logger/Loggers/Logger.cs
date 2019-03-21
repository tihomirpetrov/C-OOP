namespace P01.Logger.Loggers
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Loggers.Contracts;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            consoleAppender.Append(dateTime, "Error", errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            consoleAppender.Append(dateTime, "Info", infoMessage);
        }
    }
}