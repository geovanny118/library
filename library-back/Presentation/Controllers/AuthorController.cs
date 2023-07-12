using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _authorService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _authorService.GetByIdAsync(id);
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Author author)
    {
        await _authorService.AddAsync(author);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Author author)
    {
        await _authorService.UpdateAsync(author);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _authorService.GetByIdAsync(id);
        await _authorService.DeleteAsync(entity);
        return Ok();
    }
}