namespace Wordle.Api.Models;

public class UserCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Year { get; set; }
    public string? Month { get; set; }
    public string? Day { get; set; }
    public UserCredentials(string username, string password, string year, string month, string day)
    {
        Username = username;
        Password = password;
        Year = year;
        Month = month;
        Day = day;
    }
}