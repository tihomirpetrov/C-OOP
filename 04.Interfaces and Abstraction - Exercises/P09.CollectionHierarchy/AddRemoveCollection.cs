using System.Collections.Generic;
using System.Linq;

namespace P09.CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection;
        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string element)
        {
            this.collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string result = this.collection.LastOrDefault();
            if (this.collection.Any())
            {
                this.collection.RemoveAt(this.collection.Count - 1);
            }
            return result;
        }
    }
}
