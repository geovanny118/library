using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Book> books = await _bookService.GetAll();
        var booksDto = _mapper.Map<IEnumerable<BookResponseDto>>(books);
        return Ok(booksDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Search(int id)
    {
        Book entity = await _bookService.Search(id);
        var bookDto = _mapper.Map<BookResponseDto>(entity);
        return bookDto is null ? NotFound() : Ok(bookDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookCreateDto bookDto)
    {
        Book bookToCreate = _mapper.Map<Book>(bookDto);
        await _bookService.Create(bookToCreate);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BookUpdateDto bookDto)
    {
        Book bookToUpdate = await _bookService.Search(bookDto.Id);
        _mapper.Map(bookDto, bookToUpdate);
        await _bookService.Update(bookToUpdate);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        BookDeleteDto bookDto = new BookDeleteDto
        {
            Id = id
        };

        Book book = _mapper.Map<Book>(bookDto);
        await _bookService.Delete(book);

        return Ok();
    }
}