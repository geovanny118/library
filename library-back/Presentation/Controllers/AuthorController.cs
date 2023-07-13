using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Author> authors = await _authorService.GetAllAsync();
        var authorsDto = _mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
        return Ok(authorsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Author entity = await _authorService.GetByIdAsync(id);
        var authorDto = _mapper.Map<AuthorResponseDto>(entity);
        return authorDto is null ? NotFound() : Ok(authorDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorCreateDto authorDto)
    {
        var authorToCreate = _mapper.Map<Author>(authorDto);
        await _authorService.AddAsync(authorToCreate);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AuthorUpdateDto authorDto)
    {
        var authorToUpdate = await _authorService.GetByIdAsync(authorDto.Id);
        _mapper.Map(authorDto, authorToUpdate);
        await _authorService.UpdateAsync(authorToUpdate);
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