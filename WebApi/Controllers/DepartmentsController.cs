// Controllers/DepartmentsController.cs
using Microsoft.AspNetCore.Mvc;
using Domain.Models.CreationDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;


[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetAllDepartments")]
    public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return Ok(departments);
    }

    [HttpGet("GetDepartmentById{id}")]
    public async Task<ActionResult<Department>> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpPost("CreateDepartment")]
    public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentDto departmentDto)
    {
        var department = new Department()
        {
            Name=departmentDto.Name
        };
        await _departmentService.AddDepartmentAsync(department);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
    }

    [HttpPut("UpdateDepartment{id}")]
    public async Task<ActionResult> UpdateDepartment(int id, [FromBody] CreateDepartmentDto departmentDto)
    {
        var department = new Department()
        {
            Name = departmentDto.Name
        };
        await _departmentService.UpdateDepartmentAsync(id, department);
        return NoContent();
    }

    [HttpDelete("DeleteDepartment{id}")]
    public async Task<ActionResult> DeleteDepartment(int id)
    {
        await _departmentService.DeleteDepartmentAsync(id);
        return NoContent();
    }
}
