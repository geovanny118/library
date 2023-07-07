using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ITitleService _titleService;

    public BookController(IBookService bookService, ITitleService titleService)
    {
        _bookService = bookService;
        _titleService = titleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _bookService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _bookService.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Book book)
    {
        // Buscar el título en la base de datos 
        var title = await _titleService.GetByIdAsync(book.TitleId);

        if(title != null)
        {
            book.Title = title;
            await _bookService.AddAsync(book);
            return Ok();
        }
        else
        {
            return BadRequest("El título no existe en la base de datos.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Book book)
    {
        // Buscar el título en la base de datos 
        var title = await _titleService.GetByIdAsync(book.TitleId);

        if (title != null)
        {
            book.Title = title;
            await _bookService.UpdateAsync(book);
            return Ok();
        }
        else
        {
            return BadRequest("El título no existe en la base de datos.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _bookService.GetByIdAsync(id);
        await _bookService.DeleteAsync(entity);
        return Ok();
    }
}