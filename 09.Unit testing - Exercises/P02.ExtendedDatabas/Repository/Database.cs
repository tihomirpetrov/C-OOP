namespace P02.ExtendedDatabase.Repository
{
    using P02.ExtendedDatabase.Interfaces;
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
        public void Add(IPerson person)
        {
            if (this.people.Any(x =>x.Id == person.Id || x.Username == person.Username))
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            this.people.RemoveWhere(x => x.Id == person.Id && x.Username == person.Username);
        }

        public IPerson Find(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var personFound = this.people.FirstOrDefault(x => x.Id == id);

            if (personFound == null)
            {
                throw new ArgumentNullException();
            }

            return personFound;
        }

        public IPerson Find(string username)
        {
            if (username == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            var personFound = this.people.FirstOrDefault(x => x.Username == username);

            if (personFound == null)
            {
                throw new InvalidOperationException();
            }

            return personFound;
        }
    }
}