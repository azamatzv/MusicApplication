using Application.Models.Users;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);


            return Ok(user);
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();


        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserModel userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var createdUser = await _userService.AddUserAsync(userDto);


            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message, Details = ex.InnerException?.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserModel userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userDto);


            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);


            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }
}