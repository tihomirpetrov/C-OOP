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

        public void Add()
        {

        }

        public void Remove()
        {

        }

        public int[] Fetch()
        {
            return null;
        }
    }
}