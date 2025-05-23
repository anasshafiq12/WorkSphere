using Application.IServices;
using Domain.Models.CreationDtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ToDoController : ControllerBase
	{
		private readonly IToDoService _toDoService;

		public ToDoController(IToDoService toDoService)
		{
			_toDoService = toDoService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ToDo>>> GetAll()
		{
		
			var todos = await _toDoService.GetAllAsync();
			return Ok(todos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ToDo>> GetById(int id)
		{
			var todo = await _toDoService.GetByIdAsync(id);
			if (todo == null)
			{
				return NotFound();
			}
			return Ok(todo);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreateToDo createDto)
		{
			var todo = new ToDo
			{
				Content = createDto.Content,
				isDone = createDto.isDone
			};



			await _toDoService.AddAsync(todo);
			return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, CreateToDo updateDto)
		{
			var existing = await _toDoService.GetByIdAsync(id);
			if (existing == null)
			{
				return NotFound();
			}

			existing.Content = updateDto.Content;
			existing.isDone = updateDto.isDone;

			await _toDoService.UpdateAsync(existing);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var existing = await _toDoService.GetByIdAsync(id);
			if (existing == null)
			{
				return NotFound();
			}

			await _toDoService.DeleteAsync(id);
			return NoContent();
		}
	}
}
