using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

public class ToDoRepository : IToDoRepository
{
	private readonly AppDbContext _context;

	public ToDoRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<ToDo>> GetAllAsync()
	{
		return await _context.ToDos.ToListAsync();
	}

	public async Task<ToDo> GetByIdAsync(int id)
	{
		return await _context.ToDos.FindAsync(id);
	}

	public async Task AddAsync(ToDo todo)
	{
	

		await _context.ToDos.AddAsync(todo);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(ToDo updatedToDo)
	{
		var existingToDo = await _context.ToDos.FindAsync(updatedToDo.Id);
		if (existingToDo != null)
		{
			existingToDo.Content = updatedToDo.Content;
			existingToDo.isDone = updatedToDo.isDone;
			await _context.SaveChangesAsync();
		}
	}

	public async Task DeleteAsync(int id)
	{
		var todo = await _context.ToDos.FindAsync(id);
		if (todo != null)
		{
			_context.ToDos.Remove(todo);
			await _context.SaveChangesAsync();
		}
	}
}
