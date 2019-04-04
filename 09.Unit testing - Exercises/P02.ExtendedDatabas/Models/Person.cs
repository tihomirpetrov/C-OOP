namespace P02.ExtendedDatabase.Models
{
    using P02.ExtendedDatabase.Interfaces;
    public class Person : IPerson
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; private set; }
        public string Username { get; private set; }
    }
}