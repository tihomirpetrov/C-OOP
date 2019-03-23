namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Contracts;
    using P01.Logger.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : IAppender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(Path, content);
            }
        }
    }
}