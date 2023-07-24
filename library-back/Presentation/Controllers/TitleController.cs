using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;


namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TitleController : ControllerBase 
{
    private readonly ITitleService _titleService;
    private readonly IMapper _mapper;

    public TitleController(ITitleService titleService, IMapper mapper)
    {
        _titleService = titleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Title> titles = await _titleService.GetAll();
        var titlesDto = _mapper.Map<IEnumerable<TitleResponseDto>>(titles);
        return Ok(titlesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Search(int id)
    {
        Title entity = await _titleService.Search(id);
        var titleDto = _mapper.Map<TitleResponseDto>(entity);
        return titleDto is null ? NotFound() : Ok(titleDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TitleCreateDto titleDto)
    {
        Title titleToCreate = _mapper.Map<Title>(titleDto);
        await _titleService.Create(titleToCreate);
        return Ok(titleToCreate);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TitleUpdateDto titleDto)
    {
        Title titleToUpdate = await _titleService.Search(titleDto.Id);
        _mapper.Map(titleDto, titleToUpdate);
        await _titleService.Update(titleToUpdate);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        TitleDeleteDto titleDto = new TitleDeleteDto
        {
            Id = id
        };

        Title title = _mapper.Map<Title>(titleDto);
        await _titleService.Delete(title);

        return Ok();
    }
}