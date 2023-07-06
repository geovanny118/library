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

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _genderService.GetAllAsync());
    }
}
