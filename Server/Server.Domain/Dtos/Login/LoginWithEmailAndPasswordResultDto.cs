namespace Server.Domain.Dtos.Login;

public record LoginWithEmailAndPasswordResultDto
(
    int? UserId,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Token
);