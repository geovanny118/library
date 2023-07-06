using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenderController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GenderController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _genderService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _genderService.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }
}
