namespace P01.StreamProgressInfo
{
    using System;
    using Models;
    using Streams;

    public class Startup
    {
        public static void Main()
        {
            File file = new File("File name", 1234, 123);
            var fileProcessInfo = new StreamProgressInfo(file);
            Console.WriteLine(fileProcessInfo.CalculateCurrentPercent());

            Music music = new Music("Singer", "Album", 123456, 12349);
            var musicProcessInfo = new StreamProgressInfo(music);
            Console.WriteLine(musicProcessInfo.CalculateCurrentPercent());
        }
    }
}