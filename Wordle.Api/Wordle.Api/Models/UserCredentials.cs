namespace Wordle.Api.Models;

public class UserCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }
    public UserCredentials(string username, string password)
    {
        Username = username;
        Password = password;
    }
}