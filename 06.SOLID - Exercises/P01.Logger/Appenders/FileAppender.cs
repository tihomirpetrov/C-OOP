namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Contracts;
    using P01.Logger.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(Path, content);
                this.MessagesCount++;

                logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {base.ReportLevel}, Messages appended: {MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}