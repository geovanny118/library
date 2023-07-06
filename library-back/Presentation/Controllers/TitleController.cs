using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TitleController : ControllerBase 
{
    private readonly ITitleService _titleService;

    public TitleController(ITitleService titleService)
    {
        _titleService = titleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _titleService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _titleService.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Title title)
    {
        await _titleService.AddAsync(title);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Title title)
    {
        await _titleService.UpdateAsync(title);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _titleService.GetByIdAsync(id);
        await _titleService.DeleteAsync(entity);
        return Ok();
    }
}