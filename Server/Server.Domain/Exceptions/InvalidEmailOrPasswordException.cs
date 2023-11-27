namespace Server.Domain.Exceptions;

public class InvalidEmailOrPasswordException : Exception
{
    public InvalidEmailOrPasswordException() : base("Email or Password is incorrect") { }
}