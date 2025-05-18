﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models.CreationDtos;
using Domain.Models;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Department> GetDepartmentByIdAsync(int id);
    Task AddDepartmentAsync(Department departmentDto);
    Task UpdateDepartmentAsync(int id, Department departmentDto);
    Task DeleteDepartmentAsync(int id);
}

