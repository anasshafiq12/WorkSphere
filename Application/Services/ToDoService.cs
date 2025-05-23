using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Domain.Models;

namespace Application.Services
{
	public class ToDoService: IToDoService
	{
		private readonly IToDoRepository _ToDoRepository;

		public ToDoService(IToDoRepository toDoRepository) {
			_ToDoRepository = toDoRepository;
		}

		public async Task<IEnumerable<ToDo>> GetAllAsync()
		{
			return await _ToDoRepository.GetAllAsync();
		}
		public async Task<ToDo> GetByIdAsync(int id)
		{
			return await _ToDoRepository.GetByIdAsync(id);
		}
		public async Task AddAsync(ToDo todo)
		{
			await _ToDoRepository.AddAsync(todo);
		}
		public async Task UpdateAsync(ToDo todo)
		{
			await _ToDoRepository.UpdateAsync(todo);
		}
		public async Task DeleteAsync(int id)
		{
			await _ToDoRepository.DeleteAsync(id);
		}
	}
}
