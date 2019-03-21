namespace P01.Logger
{
    using P01.Logger.Appenders;
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Layouts;
    using P01.Logger.Layouts.Contracts;
    using P01.Logger.Loggers.Contracts;
    using P01.Logger.Loggers;
    
    public class Startup
    {
        public static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }
    }
}