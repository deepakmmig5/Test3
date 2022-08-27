using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test3.Models;
using Test3.Repositories;

namespace Test3.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CentreController : ControllerBase
{
    private readonly ICentresRepositories _centres;
    private readonly IMapper _mapper;

    public CentreController(ICentresRepositories centres,IMapper mapper)
    {
        _centres=centres;
        _mapper=mapper;
    }
    [HttpPost("CreateCentre")]
    public async Task<IActionResult> CreateCenter(Centres obj)
    {
        return Ok(await _centres.Create(obj));
    }

    [HttpPost("CreateCentreDTO")]
    public async Task<IActionResult> CreateCenterDTO(CentresDTO obj)
    {
        return Ok(await _centres.Create(
            
            _mapper.Map<Centres>(obj)
        ));
    }

    [HttpGet("GetCentres")]
    public IActionResult GetCentres()
    {
        return Ok(_centres.GetCentres());
    }
}
