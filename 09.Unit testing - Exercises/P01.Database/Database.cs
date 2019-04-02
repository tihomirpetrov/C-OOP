namespace P01.Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private int[] database;
        private int numbers;

        public Database(params int[] data)
        {
            if (data.Length > 16)
            {
                throw new InvalidOperationException();
            }

            this.database = new int[16];
            this.numbers = data.Length;

            Array.Copy(data, database, data.Length);
        }

        public void Add(int number)
        {
            if (database.Length == 16)
            {
                throw new InvalidOperationException();
            }

            this.database[numbers++] = number;
        }

        public int Remove()
        {
            if (database.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return this.database[--numbers];
        }

        public int[] Fetch()
        {
            return this.database.Take(numbers).ToArray();
        }
    }
}