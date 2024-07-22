using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Domain.Constants;

namespace Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Authorize(PermissionsTree.Categories.View)]
    public async Task<IActionResult> GetCategories()
    {
        
        return Ok();
    }
}