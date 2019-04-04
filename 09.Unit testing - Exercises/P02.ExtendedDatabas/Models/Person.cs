namespace P02.ExtendedDatabas.Models
{
    using P02.ExtendedDatabas.Interfaces;
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