namespace Wordle.Api.Models;

public class UserCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }

    /* Must remain public, else the following error is thrown when connecting to 'GetToken' API:
     System.NotSupportedException: Deserialization of types without a parameterless constructor, a singular
     parameterized constructor, or a parameterized constructor annotated with 'JsonConstructorAttribute' is not
     supported. Type 'Wordle.Api.Models.UserCredentials'. Path: $ | LineNumber: 0 | BytePositionInLine: 1.
     */
    public UserCredentials(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
