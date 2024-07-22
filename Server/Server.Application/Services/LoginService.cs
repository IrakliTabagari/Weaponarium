using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Server.Domain.Constants;
using Server.Domain.Dtos.Login;
using Server.Domain.Entities;
using Server.Domain.Exceptions;
using Server.Domain.Interfaces.Services;

namespace Server.Application.Services;

public class LoginService : ILoginService
{
    
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;

    public LoginService(UserManager<User> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }
    
    public async Task<Result<LoginWithEmailAndPasswordResultDto>> LoginWithUserNameAndPassword(string email, string password)
    {
        // if (string.IsNullOrWhiteSpace(email)) { return new Result<LoginWithEmailAndPasswordResultDto>(new ValidationException()}

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            return new Result<LoginWithEmailAndPasswordResultDto>(new InvalidEmailOrPasswordException());         

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName ?? ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        // Add Role Names as Claims
        foreach (var userRole in user.UserRoles)
        {
            if (authClaims.Any(c => c.Value == userRole.Role.Name)) continue;
            authClaims.Add(new Claim(CustomClaims.Roles, userRole.Role.Name));
        }

        // Add Permissions as Claims
        foreach (var userRole in user.UserRoles.Where(ur => ur.Role.RoleClaims.Count != 0))
        {
            foreach (var roleClaim in userRole.Role.RoleClaims)
            {
                if (authClaims.Any(c => c.Value == roleClaim.Name)) continue;
                authClaims.Add(new Claim(CustomClaims.Permissions, roleClaim.Name));
            }
        }

        var token = _jwtService.GenerateToken(authClaims);

        var loginData = new LoginWithEmailAndPasswordResultDto(
            UserId: user.Id,
            FirstName: user.FirstName,
            LastName: user.LastName,
            Email: user.Email,
            Token: token
        );

        return new Result<LoginWithEmailAndPasswordResultDto>(loginData);
    }
}