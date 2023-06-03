namespace Wordle.Api.Models
{
    public class CreateUser : UserCredentials
    {
        public CreateUser(string username, string password, string name, string year, string month, string day) : base(username, password)
        {
            Name = name;
            Year =  year;
            Month = month;
            Day = day;
        }

        public string Name { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }
}
