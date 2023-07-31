using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenderController : ControllerBase
{
    private readonly IGenderService _genderService;
    private readonly IMapper _mapper;

    public GenderController(IGenderService genderService, IMapper mapper)
    {
        _genderService = genderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Gender> genders = await _genderService.GetAll();
        var gendersDto = _mapper.Map<IEnumerable<GenderResponseDto>>(genders);
        return Ok(gendersDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Search(int id)
    {
        Gender entity = await _genderService.Search(id);
        var genderDto = _mapper.Map<GenderResponseDto>(entity);
        return genderDto is null ? NotFound() : Ok(genderDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenderCreateDto genderDto)
    {
        var genderToCreate = _mapper.Map<Gender>(genderDto);
        await _genderService.Create(genderToCreate);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GenderUpdateDto genderDto)
    {
        var genderToUpdate = await _genderService.Search(genderDto.Id);
        _mapper.Map(genderDto, genderToUpdate);
        await _genderService.Update(genderToUpdate);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        GenderDeleteDto genderDto = new GenderDeleteDto
        {
            Id = id
        };

        Gender gender = _mapper.Map<Gender>(genderDto);
        await _genderService.Delete(gender);

        return Ok();
    }
}