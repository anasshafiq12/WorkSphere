// EmployeeRepository.cs
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

	public static List<Employee> GetDummyEmployees()
	{
		return new List<Employee>
		{
			new Employee { Name = "Ahmed Khan", Phone = "03001234567", JoinDate = new DateTime(2022, 1, 15), Role = "Developer", Email = "ahmed.khan@example.com", ImagePath = "https://i.pravatar.cc/32?img=8", PerMonthSalary = 90000, TotalSalaryTaken = 270000 },
			new Employee {  Name = "Fatima Noor", Phone = "03011234567", JoinDate = new DateTime(2021, 11, 10), Role = "Sales", Email = "fatima.noor@example.com", ImagePath = "https://i.pravatar.cc/32?img=9", PerMonthSalary = 60000, TotalSalaryTaken = 360000 },
			new Employee {  Name = "Ali Raza", Phone = "03021234567", JoinDate = new DateTime(2023, 5, 5), Role = "Developer", Email = "ali.raza@example.com", ImagePath = "https://i.pravatar.cc/32?img=10", PerMonthSalary = 75000, TotalSalaryTaken = 150000 },
			new Employee {  Name = "Zainab Qureshi", Phone = "03031234567", JoinDate = new DateTime(2022, 8, 20), Role = "Marketing", Email = "zainab.q@example.com", ImagePath = "https://i.pravatar.cc/32?img=11", PerMonthSalary = 55000, TotalSalaryTaken = 220000 },
			new Employee { Name = "Usman Tariq", Phone = "03041234567", JoinDate = new DateTime(2020, 3, 1), Role = "Sales", Email = "usman.tariq@example.com", ImagePath = "https://i.pravatar.cc/32?img=12", PerMonthSalary = 85000, TotalSalaryTaken = 510000 },
			new Employee { Name = "Ayesha Malik", Phone = "03051234567", JoinDate = new DateTime(2023, 1, 12), Role = "Marketing", Email = "ayesha.m@example.com", ImagePath = "https://i.pravatar.cc/32?img=13", PerMonthSalary = 70000, TotalSalaryTaken = 280000 },
			new Employee { Name = "Hamza Sheikh", Phone = "03061234567", JoinDate = new DateTime(2021, 9, 25), Role = "Developer", Email = "hamza.s@example.com", ImagePath = "https://i.pravatar.cc/32?img=14", PerMonthSalary = 80000, TotalSalaryTaken = 400000 },
			new Employee { Name = "Mariam Shah", Phone = "03071234567", JoinDate = new DateTime(2022, 7, 30), Role = "Sales", Email = "mariam.shah@example.com", ImagePath = "https://i.pravatar.cc/32?img=15", PerMonthSalary = 65000, TotalSalaryTaken = 260000 },
			new Employee {  Name = "Bilal Ahmed", Phone = "03081234567", JoinDate = new DateTime(2024, 2, 14), Role = "Developer", Email = "bilal.ahmed@example.com", ImagePath = "https://i.pravatar.cc/32?img=16", PerMonthSalary = 25000, TotalSalaryTaken = 75000 },
			new Employee {  Name = "Sana Javed", Phone = "03091234567", JoinDate = new DateTime(2023, 10, 5), Role = "Marketing", Email = "sana.j@example.com", ImagePath = "https://i.pravatar.cc/32?img=17", PerMonthSalary = 60000, TotalSalaryTaken = 120000 }
		};
	}
	public async Task AddAsync(Employee employee)
    {
       // List<Employee> list = GetDummyEmployees();
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
