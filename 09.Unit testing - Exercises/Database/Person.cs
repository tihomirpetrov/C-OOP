using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Person
    {
        private string name;
        private long id;


        public Person(string name, long id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get => name; private set => name = value; }
        public long Id { get => id; private set => id = value; }
    }
}
