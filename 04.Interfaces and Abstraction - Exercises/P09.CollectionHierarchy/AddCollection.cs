using System.Collections.Generic;

namespace P09.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string element)
        {
            this.collection.Add(element);
            return this.collection.Count - 1;
        }
    }
}
