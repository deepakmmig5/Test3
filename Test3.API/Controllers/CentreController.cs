using Microsoft.AspNetCore.Mvc;
using Test3.Models;
using Test3.Repositories;

namespace Test3.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CentreController : ControllerBase
{
    private readonly ICentresRepositories _centres;
    public CentreController(ICentresRepositories centres)
    {
        _centres=centres;
    }
    [HttpPost("CreateCentre")]
    public async Task<IActionResult> CreateCenter(Centres obj)
    {
        return Ok(await _centres.Create(obj));
    }
}
