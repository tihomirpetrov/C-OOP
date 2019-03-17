using System.Collections.Generic;
using System.Linq;

namespace P09.CollectionHierarchy
{
    public class MyList : IMyList
    {
        public MyList()
        {
            this.collection = new List<string>();
            this.Count = this.collection.Count;
        }
        private List<string> collection;
        public int Count { get; set; }
        public int Add(string element)
        {
            this.collection.Insert(0, element);
            this.Count++;
            return 0;
        }

        public string Remove()
        {
            string result = this.collection.FirstOrDefault();
            if (this.collection.Any())
            {
                this.collection.RemoveAt(0);
                this.Count--;
            }

            return result;
        }
    }
}
