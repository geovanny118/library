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
        IEnumerable<Gender> genders = await _genderService.GetAllAsync();
        var gendersDto = _mapper.Map<IEnumerable<GenderResponseDto>>(genders);
        return Ok(gendersDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Gender entity = await _genderService.GetByIdAsync(id);
        var genderDto = _mapper.Map<GenderResponseDto>(entity);
        return genderDto is null ? NotFound() : Ok(genderDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenderCreateDto genderDto)
    {
        var genderToCreate = _mapper.Map<Gender>(genderDto);
        await _genderService.AddAsync(genderToCreate);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GenderUpdateDto genderDto)
    {
        var genderToUpdate = await _genderService.GetByIdAsync(genderDto.Id);
        _mapper.Map(genderDto, genderToUpdate);
        await _genderService.UpdateAsync(genderToUpdate);
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
        await _genderService.DeleteAsync(gender);

        return Ok();
    }
}