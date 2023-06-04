namespace Wordle.Api.Models;

public class UserCredentials
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserCredentials(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}
