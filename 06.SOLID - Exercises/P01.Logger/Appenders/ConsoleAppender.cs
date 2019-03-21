namespace P01.Logger.Appenders
{
    using P01.Logger.Appenders.Contracts;
    using System;

    public class ConsoleAppender : IAppender
    {
        public void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine();
        }
    }
}