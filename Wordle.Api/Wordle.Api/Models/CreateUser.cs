namespace Wordle.Api.Models
{
    public class CreateUser : UserCredentials
    {
        public CreateUser(string username, string password, string name) : base(username, password)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}