using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Domain.Constants;

namespace Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    
    [HttpGet]
    [Authorize(PermissionsTree.Roles.View)]
    public async Task<IActionResult> GetRoles()
    {
        
        return Ok();
    }
}