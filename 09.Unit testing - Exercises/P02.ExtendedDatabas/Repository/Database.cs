namespace P02.ExtendedDatabas.Repository
{
    using P02.ExtendedDatabas.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private HashSet<IPerson> people;

        public Database()
        {
            this.people = new HashSet<IPerson>();
        }

        public Database(IEnumerable<IPerson> people) 
            : this()
        {
            if (people != null)
            {
                foreach (var person in people)
                {
                    this.Add(person);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.people.Count;
            }
        }
        private void Add(IPerson person)
        {
            if (this.people.Any(x =>x.Id == person.Id || x.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }
    }
}