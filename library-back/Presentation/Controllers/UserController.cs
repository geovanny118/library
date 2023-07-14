using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Library.Business.Interfaces;
using Library.Infrastructure.Dtos;
using Library.Infrastructure.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<User> users = await _userService.GetAllAsync();
        var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(users);
        return Ok(usersDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        User entity = await _userService.GetByIdAsync(id);
        var userDto = _mapper.Map<UserResponseDto>(entity);
        return userDto is null ? NotFound() : Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
    {
        User userToCreate = _mapper.Map<User>(userDto);
        await _userService.AddAsync(userToCreate);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto userDto)
    {
        User userToUpdate = await _userService.GetByIdAsync(userDto.Id);
        _mapper.Map(userDto, userToUpdate);
        await _userService.UpdateAsync(userToUpdate);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        User entity = await _userService.GetByIdAsync(id);
        await _userService.DeleteAsync(entity);
        return Ok();
    }
}