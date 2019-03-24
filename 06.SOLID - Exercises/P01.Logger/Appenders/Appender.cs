namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Enums;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public int MessagesCount { get; set; }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

    }
}
