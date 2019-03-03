namespace P06.Sneaking
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] room = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }

            char[] directions = Console.ReadLine().ToCharArray();
            int SamRow = -1;
            int SamCol = -1;

            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('S'))
                {
                    SamRow = row;
                    SamCol = Array.IndexOf(room[row], 'S');
                }
            }

            room[SamRow][SamCol] = '.';

            for (int i = 0; i < directions.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    if (room[row].Contains('b'))
                    {
                        int colB = Array.IndexOf(room[row], 'b');
                        if (room[row].Length - 1 == colB)
                        {
                            room[row][colB] = 'd';
                        }
                        else
                        {
                            room[row][colB] = '.';
                            room[row][colB + 1] = 'b';
                        }
                    }

                    else if (room[row].Contains('d'))
                    {
                        int colD = Array.IndexOf(room[row], 'd');
                        if (colD == 0)
                        {
                            room[row][colD] = 'b';
                        }
                        else
                        {
                            room[row][colD] = '.';
                            room[row][colD - 1] = 'd';
                        }
                    }
                }
                if (room[SamRow].Contains('b'))
                {
                    int colB = Array.IndexOf(room[SamRow], 'b');
                    if (colB < SamCol)
                    {
                        room[SamRow][SamCol] = 'X';
                        Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                        break;
                    }
                }
                else if (room[SamRow].Contains('d'))
                {
                    int colD = Array.IndexOf(room[SamRow], 'd');
                    if (colD > SamCol)
                    {
                        room[SamRow][SamCol] = 'X';
                        Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                        break;
                    }
                }
                switch (directions[i])
                {
                    case 'U':
                        SamRow--;
                        break;
                    case 'D':
                        SamRow++;
                        break;
                    case 'L':
                        SamCol--;
                        break;
                    case 'R':
                        SamCol++;
                        break;
                }
                if (room[SamRow].Contains('N'))
                {
                    int indexOfN = Array.IndexOf(room[SamRow], 'N');
                    room[SamRow][indexOfN] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    room[SamRow][SamCol] = 'S';
                    break;
                }
                if (room[SamRow][SamCol] == 'd' || room[SamRow][SamCol] == 'b')
                {
                    room[SamRow][SamCol] = '.';
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(row);
            }
        }
    }
}