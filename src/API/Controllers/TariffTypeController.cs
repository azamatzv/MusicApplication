using Application.Models.TariffTypes;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TariffTypeController : ControllerBase
{
    private readonly ITariffTypeService _tariffTypeService;

    public TariffTypeController(ITariffTypeService tariffTypeService)
    {
        _tariffTypeService = tariffTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTariffAsync([FromBody] CreateTariffTypeModel tariffTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var added = await _tariffTypeService.AddTariffAsync(tariffTypeDto);

            return Ok(new
            {
                message = "Tariff successfully added.",
                tariff = added
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while adding the tariff.", details = ex.Message });
        }
    }
}