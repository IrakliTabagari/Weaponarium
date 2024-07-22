using LanguageExt.Common;
using Server.Domain.Dtos.Roles;
using Server.Domain.Entities;
using Server.Domain.Interfaces.Services;

namespace Server.Application.Services;

public class RolesService : IRolesService
{
    public Task<Result<List<RoleDto>>> GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public Task<Result<RoleDto>> GetRoleById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRole(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RoleDto>> CreateRole(Role role)
    {
        throw new NotImplementedException();
    }
}