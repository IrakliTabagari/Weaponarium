using LanguageExt.Common;
using Server.Domain.Dtos.Roles;
using Server.Domain.Entities;

namespace Server.Domain.Interfaces.Services;

public interface IRoleService
{
    Task<Result<List<RoleDto>>> GetAllRoles();
    Task<Result<RoleDto>> GetRoleById(int id);
    Task UpdateRole(Role role);
    Task DeleteRole(Role role);
    Task<Result<RoleDto>> CreateRole(Role role);
}