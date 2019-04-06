using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class DataBaseClass
    {
        private int[] intStorage;
        private int currentIndex = 0;
        private List<Person> people;

        public DataBaseClass(int[] intStorage)
        {
            this.IntStorage = intStorage;
            currentIndex = this.IntStorage[this.IntStorage.Length - 1];
        }

        public DataBaseClass()
        {
            this.intStorage = new int[16];
        }

        public DataBaseClass(List<Person> people)
        {
            this.People = people;
        }

        public int[] IntStorage
        {
            get => intStorage;
            private set
            {
                if (value.Length > 16)
                {
                    throw new InvalidOperationException("Size should be maximum 16 elements!");
                }
                this.intStorage = value;
            }
        }

        public List<Person> People { get => people; private set => people = value; }

        public void Add(int value)
        {
            if (this.IntStorage[this.IntStorage.Length - 1] != 0)
            {
                throw new InvalidOperationException($"Can`t add more than {this.IntStorage.Length} elements!");
            }

            this.IntStorage[this.currentIndex++] = value;
        }

        public void Remove()
        {
            if (this.IntStorage[0] == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.IntStorage[--currentIndex] = 0;
        }

        public int[] Fetch()
        {
            return this.IntStorage.Take(this.currentIndex).ToArray();
        }

        public void AddPerson(Person person)
        {
            if (this.People.Any(x => x.Name == person.Name))
            {
                throw new InvalidOperationException($"A person with that name is already registered!");
            }
            if (this.People.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException($"A person with that Id is already registered!");
            }
            this.people.Add(person);
        }

        public void RemovePerson(Person person)
        {
            if (!this.People.Any(x => x.Name == person.Name))
            {
                throw new InvalidOperationException($"Person with name {person.Name} does not exist in the database!");
            }
            this.People.Remove(person);
        }

        public Person FindByUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
            {
                throw new InvalidOperationException("Invalid username!");
            }
            if (!this.People.Any(x => x.Name == userName))
            {
                throw new InvalidOperationException($"No user with name {userName} found!");
            }

            return this.People.FirstOrDefault(x => x.Name == userName);
        }

        public Person FindById(long id)
        {
            if (this.People.Any(x => x.Id == id) && id < 0)
            {
                throw new ArgumentOutOfRangeException($"Id should be a possitive number!");
            }
            if (!this.People.Any(x => x.Id == id))
            {
                throw new InvalidOperationException($"No user with id {id} found!");
            }
       
            return this.People.FirstOrDefault(x => x.Id == id);
        }
    }
}
