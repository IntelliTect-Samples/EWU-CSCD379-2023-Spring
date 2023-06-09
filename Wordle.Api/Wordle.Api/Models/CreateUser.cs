namespace Wordle.Api.Models
{
    public class CreateUser: UserCredentials
    {
        public CreateUser(string username, string password, string name):base(username, password)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
