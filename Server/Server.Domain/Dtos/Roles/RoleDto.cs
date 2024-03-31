namespace Server.Domain.Dtos.Roles;

public record RoleDto(
    string Id,
    string Name,
    string Description,
    List<string> Permissions);