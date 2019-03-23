namespace P01.Logger.Loggers
{
    using System;
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Loggers.Contracts;
    using P01.Logger.Loggers.Enums;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;


        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.Critical, criticalMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            this.Append(dateTime, ReportLevel.Warning, warningMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, ReportLevel.Fatal, fatalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, ReportLevel.Error, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, ReportLevel.Info, infoMessage);
        }

        private void Append(string dateTime, ReportLevel type, string message)
        {
            consoleAppender?.Append(dateTime, type, message);
            fileAppender?.Append(dateTime, type, message);
        }
    }
}