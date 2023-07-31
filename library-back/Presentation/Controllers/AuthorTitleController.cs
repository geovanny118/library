using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorTitleController : Controller
{
    private readonly IAuthorTitleService _authorTitleService;
    private readonly IMapper _mapper;

    public AuthorTitleController(IAuthorTitleService authorTitleService, IMapper mapper)
    {
        _authorTitleService = authorTitleService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorTitleCreateDto authorTitleDto)
    {
        var authorTitleToCreate = _mapper.Map<AuthorsTitle>(authorTitleDto);
        await _authorTitleService.Create(authorTitleToCreate);
        return Ok(authorTitleToCreate);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AuthorTitleUpdateDto authorTitleDto)
    {
        var authorTitleToUpdate = await _authorTitleService.Search(authorTitleDto.Id);
        _mapper.Map(authorTitleDto, authorTitleToUpdate);
        await _authorTitleService.Update(authorTitleToUpdate);
        return Ok(authorTitleToUpdate);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        AuthorTitleDeleteDto authorTitleDto = new AuthorTitleDeleteDto { Id = id };

        AuthorsTitle authorsTitle = _mapper.Map<AuthorsTitle>(authorTitleDto);
        await _authorTitleService.Delete(authorsTitle);

        return Ok();
    }
}