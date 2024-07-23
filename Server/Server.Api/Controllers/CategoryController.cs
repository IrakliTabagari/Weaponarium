using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Domain.Constants;
using Server.Domain.Interfaces.Services;

namespace Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [Authorize(PermissionsTree.Categories.View)]
    public async Task<IActionResult> GetCategories()
    {
        
        return Ok();
    }
}