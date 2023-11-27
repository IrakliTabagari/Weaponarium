using LanguageExt.Common;
using Server.Domain.Dtos.Login;

namespace Server.Domain.Interfaces.Services;

public interface ILoginService
{
    Task<Result<LoginWithEmailAndPasswordResultDto>> LoginWithUserNameAndPassword(string email, string password);
}