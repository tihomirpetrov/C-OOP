namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {base.ReportLevel}, Messages appended: {MessagesCount}";
        }
    }
}