using System.ComponentModel.DataAnnotations;

namespace Server.Api.Models.Login.Request;

public record class LoginWithEmailAndPasswordRequestModel
{
    [Required]
    [MinLength(3)]
    [EmailAddress(ErrorMessage = "Email address is not valid.")]
    public required string Email { get; set; }
    
    [Required]
    [MinLength(3)]
    public required string Password { get; set; }
}