namespace P01.Database
{
    using System;

    public class Database
    {
        private int[] database;
        private int numbers;

        public Database(int[] database)
        {
            if (database.Length > 16)
            {
                throw new InvalidOperationException();
            }

            this.database = new int[16];
            this.numbers = database.Length;
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
            return null;
        }
    }
}