﻿namespace P01.Logger.Loggers
{
    using System;
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Loggers.Contracts;

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
            this.Append(dateTime, "Critical", criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, "Fatal", fatalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, "Error", errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, "Info", infoMessage);
        }

        private void Append(string dateTime, string type, string message)
        {
            consoleAppender?.Append(dateTime, type, message);
            fileAppender?.Append(dateTime, type, message);
        }
    }
}