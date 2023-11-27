namespace Server.Domain.Exceptions;

public class InvalidUserNameOrPasswordException : Exception 
{ 
    public InvalidUserNameOrPasswordException() : base("UserName or Password is incorrect") { }
}