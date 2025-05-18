// DepartmentRepository.c
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments
                             .Include(d => d.Employees) // Include Employees
                             .ToListAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Departments
                             .Include(d => d.Employees)
                             .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
