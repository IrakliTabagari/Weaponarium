using System.ComponentModel.DataAnnotations;

namespace Server.Api.Models.Login.Request;

public record class LoginWithEmailAndPasswordRequestModel
{
    [Required(ErrorMessage = "Email is required")]
    [MinLength(3, ErrorMessage = "Email length must be minimum 3 letters")]
    [EmailAddress(ErrorMessage = "Email address is not valid.")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(3, ErrorMessage = "Password length must be minimum 3 letters")]
    public required string Password { get; set; }
}