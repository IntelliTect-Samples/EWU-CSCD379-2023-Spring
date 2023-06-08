namespace Wordle.Api.Models
{
    public class CreateUser : UserCredentials
    {
        public CreateUser(string username, string password, string name, DateTime? birthdate) : base(username, password)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}