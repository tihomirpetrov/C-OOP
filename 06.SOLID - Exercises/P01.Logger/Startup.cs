namespace P01.Logger
{
    using Appenders;
    using Appenders.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using Loggers.Contracts;
    using Loggers;
    
    public class Startup
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}