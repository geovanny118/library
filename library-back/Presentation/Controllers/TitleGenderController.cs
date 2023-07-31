using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TitleGenderController : Controller
{
    private readonly ITitleGenderService _titleGenderService;
    private readonly IMapper _mapper;

    public TitleGenderController(ITitleGenderService titleGenderService, IMapper mapper)
    {
        _titleGenderService = titleGenderService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TitleGenderCreateDto titleGenderDto)
    {
        var titleGenderToCreate = _mapper.Map<TitlesGender>(titleGenderDto);
        await _titleGenderService.Create(titleGenderToCreate);
        return Ok(titleGenderToCreate);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TitleGenderUpdateDto titleGenderDto)
    {
        var titleGenderToUpdate = await _titleGenderService.Search(titleGenderDto.Id);
        _mapper.Map(titleGenderDto, titleGenderToUpdate);
        await _titleGenderService.Update(titleGenderToUpdate);
        return Ok(titleGenderToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        TitleGenderDeleteDto titleGenderDto = new TitleGenderDeleteDto { Id = id };

        TitlesGender titlesGender = _mapper.Map<TitlesGender>(titleGenderDto);
        await _titleGenderService.Delete(titlesGender);

        return Ok();
    }
}