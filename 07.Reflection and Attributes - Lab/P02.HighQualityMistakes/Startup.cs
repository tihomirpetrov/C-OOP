namespace P02.HighQualityMistakes
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}