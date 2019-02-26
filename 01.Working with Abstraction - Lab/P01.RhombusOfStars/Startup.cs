namespace P01.RhombusOfStars
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            
            for (int starCount = 0; starCount < size; starCount++)
            {
                PrintRow(size, starCount);
            }

            for (int starCount = size - 1; starCount >= 0; starCount--)
            {
                PrintRow(size, starCount);
            }
        }

        private static void PrintRow(int figureSize, int starCount)
        {
            for (int i = 0; i < figureSize - starCount; i++)
            {
               Console.Write(" ");                
            }

            for (int col = 0; col < starCount; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine(" ");
        }
    }
}