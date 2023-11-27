using System.ComponentModel.DataAnnotations;

namespace Server.Api.Models.Login.Request;

public class LoginWithEmailAndPasswordRequestModel
{
    [Required]
    [MinLength(3)]
    [EmailAddress(ErrorMessage = "Email address is not valid.")]
    public string Email { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Password { get; set; }
}