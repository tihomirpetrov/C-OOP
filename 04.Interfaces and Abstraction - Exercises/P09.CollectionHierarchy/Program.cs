namespace P09.CollectionHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();

            AddCollection addCollection = new AddCollection();
            List<int> list = AddElements(input, addCollection);
            Console.WriteLine(string.Join(" ", list));

            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            list = AddElements(input, addRemoveCollection);
            Console.WriteLine(string.Join(" ", list));

            MyList myList = new MyList();
            list = AddElements(input, myList);
            Console.WriteLine(string.Join(" ", list));

            int numberOfRemoves = int.Parse(Console.ReadLine());
            List<string> deletedElements = new List<string>();

            deletedElements = RemoveElements(numberOfRemoves, addRemoveCollection);
            Console.WriteLine(string.Join(" ",deletedElements));

            deletedElements = RemoveElements(numberOfRemoves, myList);
            Console.WriteLine(string.Join(" ", deletedElements));
        }

        static List<int> AddElements(List<string> input, IAddCollection collection )
        {
            List<int> list = new List<int>();
            for (int i = 0; i < input.Count; i++)
            {
                int indexAdd = collection.Add(input[i]);
                list.Add(indexAdd);
            }

            return list;
        }

        static List<string> RemoveElements(int number, IAddRemoveCollection collection)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < number; i++)
            {
                string element = collection.Remove();
                list.Add(element);
            }

            return list;
        }
    }
}
