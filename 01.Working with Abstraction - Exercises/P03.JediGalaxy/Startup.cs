namespace P03.JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] coordinatesIvo = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] coordinatesEvilPower = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int coordinatesEvilPowerX = coordinatesEvilPower[0];
                int coordinatesEvilPowerY = coordinatesEvilPower[1];

                while (coordinatesEvilPowerX >= 0 && coordinatesEvilPowerY >= 0)
                {
                    if (coordinatesEvilPowerX >= 0 && coordinatesEvilPowerX < matrix.GetLength(0) && coordinatesEvilPowerY >= 0 && coordinatesEvilPowerY < matrix.GetLength(1))
                    {
                        matrix[coordinatesEvilPowerX, coordinatesEvilPowerY] = 0;
                    }
                    coordinatesEvilPowerX--;
                    coordinatesEvilPowerY--;
                }

                int coordinatesIvoX = coordinatesIvo[0];
                int coordinatesIvoY = coordinatesIvo[1];

                while (coordinatesIvoX >= 0 && coordinatesIvoY < matrix.GetLength(1))
                {
                    if (coordinatesIvoX >= 0 && coordinatesIvoX < matrix.GetLength(0) && coordinatesIvoY >= 0 && coordinatesIvoY < matrix.GetLength(1))
                    {
                        sum += matrix[coordinatesIvoX, coordinatesIvoY];
                    }

                    coordinatesIvoY++;
                    coordinatesIvoX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}