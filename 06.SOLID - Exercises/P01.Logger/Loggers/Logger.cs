namespace P01.Logger.Loggers
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Loggers.Contracts;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;


        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            consoleAppender.Append(dateTime, "Error", errorMessage);
            fileAppender.Append(dateTime, "Error", errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            consoleAppender.Append(dateTime, "Info", infoMessage);
            fileAppender.Append(dateTime, "Info", infoMessage);
        }
    }
}