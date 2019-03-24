namespace P01.Logger
{
    using P01.Logger.Core;
    using P01.Logger.Core.Contracts;

    public class Startup
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}