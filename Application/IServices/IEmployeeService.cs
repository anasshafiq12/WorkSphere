using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IEmployeeService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Models.CreationDtos;
using Domain.Models;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employeeDto);
    Task UpdateEmployeeAsync(int id, Employee employeeDto);
    Task DeleteEmployeeAsync(int id);
}
