using System.Security.Claims;

namespace Server.Domain.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(List<Claim> claims);
}