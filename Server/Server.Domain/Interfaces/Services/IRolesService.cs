using Server.Domain.Entities;

namespace Server.Domain.Interfaces.Services;

public interface IRolesService
{
    Task<List<Role>> GetAllRoles();
    Task<Role?> GetRoleById(int id);
    Task UpdateRole(Role role);
    Task DeleteRole(Role role);
    Task<Role> CreateRole(Role role);
}