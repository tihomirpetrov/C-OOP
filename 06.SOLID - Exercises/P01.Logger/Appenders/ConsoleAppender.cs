namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Enums;
    using System;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}