namespace P01.Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int count;

        public Database()
        {
            this.data = new int[Capacity];
        }

        public Database(params int[] numbers) 
            : this()

        {
            if (numbers != null)
            {
                foreach (var item in numbers)
                {
                    this.Add(item);
                }
            }            
        }
        
        public int Count
        {
            get
            {
                return this.count;
            }            
        }

        public void Add(int number)
        {
            if (this.count == this.data.Length)
            {
                throw new InvalidOperationException();
            }

            data[this.count] = number;
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }

            this.count--;
        }

        public int[] Fetch()
        {
            return this.data.Take(count).ToArray();
        }
    }
}