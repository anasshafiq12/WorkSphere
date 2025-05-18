using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.IServices;
using Domain.Models.CreationDtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientsController : ControllerBase
	{
		private readonly IClientService _clientService;

		public ClientsController(IClientService clientService)
		{
			_clientService = clientService;
		}

		// Get all clients
		[HttpGet("GetAllClients")]
		public async Task<ActionResult<IEnumerable<ClientModel>>> GetAllClients()
		{
			var clients = await _clientService.GetAllClientsAsync();
			return Ok(clients);
		}

		// Get client by ID
		[HttpGet("GetClientById/{clientId}")]
		public async Task<ActionResult<ClientModel>> GetClientById(int clientId)
		{
			var client = await _clientService.GetClientByIdAsync(clientId);
			if (client == null)
			{
				return NotFound();
			}
			return Ok(client);
		}

		// Add a new client
		[HttpPost("AddClient")]
		public async Task<ActionResult> AddClient([FromBody] CreateClientDto clientDto)
		{
			Console.WriteLine("in controleer");
			var client = new ClientModel
			{
				FirstName = clientDto.FirstName,
				LastName = clientDto.LastName,
				Email = clientDto.Email,
				Username = clientDto.Username,
				Password = clientDto.Password,
				ConfirmPassword = clientDto.ConfirmPassword,
				MobileNo = clientDto.MobileNo,
				Address = clientDto.Address,
				ProjectsRead = clientDto.ProjectsRead,
				ProjectsWrite = clientDto.ProjectsWrite,
				ProjectsDelete = clientDto.ProjectsDelete,
				TasksRead = clientDto.TasksRead,
				TasksWrite = clientDto.TasksWrite,
				TasksDelete = clientDto.TasksDelete
			}; 
			await _clientService.AddClientAsync(client);
			return CreatedAtAction(nameof(GetClientById), new { id = 1 }, clientDto);
		}

		// Update an existing client
		[HttpPut("UpdateClient/{clientId}")]
		public async Task<ActionResult> UpdateClient(int clientId, [FromBody] ClientModel clientDto)
		{
			await _clientService.UpdateClientAsync(clientId, clientDto);
			return NoContent();
		}

		// Delete a client
		[HttpDelete("DeleteClient/{clientId}")]
		public async Task<ActionResult> DeleteClient(int clientId)
		{
			await _clientService.DeleteClientAsync(clientId);
			return NoContent();
		}
	}
}

