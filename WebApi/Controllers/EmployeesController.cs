// Controllers/EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using Domain.Models.CreationDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetAllEmployees")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("GetAllEmployeesById{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost("CreateEmployee")]
    public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        var employee = new Employee()
        {
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Email = employeeDto.Email,
            ImagePath = employeeDto.ImagePath,
            Role = employeeDto.Role,
            JoinDate = employeeDto.JoinDate
        };
        await _employeeService.AddEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    [HttpPut("UpdateEmployee{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] CreateEmployeeDto employeeDto)
    {
        var employee = new Employee()
        {
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Email = employeeDto.Email,
            ImagePath = employeeDto.ImagePath,
            Role = employeeDto.Role,
            JoinDate = employeeDto.JoinDate
        };
        await _employeeService.UpdateEmployeeAsync(id, employee);
        return NoContent();
    }

    [HttpDelete("DeleteEmployee{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }
}
