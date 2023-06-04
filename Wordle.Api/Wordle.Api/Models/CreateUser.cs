namespace Wordle.Api.Models
{
    public class CreateUser: UserCredentials
    {
        public CreateUser(string username, string password, string name, string year, string month, string day):base(username, password, year, month, day)
        {
            Name = name;
            Year = year;
            Month = month;
            Day = day;
        }

        public string Name { get; set; }
    }
}
