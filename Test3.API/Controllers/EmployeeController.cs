using Microsoft.AspNetCore.Mvc;
using Test3.Repositories;
using Test3.Models;
namespace Test3.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeesRepositories _emp;

     public EmployeeController(IEmployeesRepositories emp){
       _emp=emp;
     }
    
    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(Employees obj)
    {
        return Ok(await _emp.Create(obj));
    }

    [HttpGet("GetEmployee")]
    public async Task<IActionResult> GetEmployee()
    {
        return Ok(await _emp.GetEmployees());
    }


}
