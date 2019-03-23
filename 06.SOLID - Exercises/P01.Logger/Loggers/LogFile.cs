namespace P01.Logger.Loggers
{
    using P01.Logger.Loggers.Contracts;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}