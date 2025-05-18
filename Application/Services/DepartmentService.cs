using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.CreationDtos;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> GetDepartmentByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task AddDepartmentAsync(Department departmentDto)
    {

        await _departmentRepository.AddAsync(departmentDto);
    }

    public async Task UpdateDepartmentAsync(int id, Department departmentDto)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department != null)
        {
            await _departmentRepository.UpdateAsync(departmentDto);
        }
    }

    public async Task DeleteDepartmentAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);
    }
}
