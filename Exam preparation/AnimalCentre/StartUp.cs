namespace AnimalCentre
{
    using AnimalCentre.Core;
    using AnimalCentre.Core.Contracts;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}