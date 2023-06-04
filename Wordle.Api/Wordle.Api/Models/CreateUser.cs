namespace Wordle.Api.Models
{
    public class CreateUser: UserCredentials
    {
        public CreateUser(string userName, string password, string name):base(userName, password) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
