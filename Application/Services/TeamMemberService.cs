using Application.IServices;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class TeamMemberService : ITeamMemberService
	{
		private readonly ITeamMemberRepository _teamMemberRepository;

		public TeamMemberService(ITeamMemberRepository teamMemberRepository)
		{
			_teamMemberRepository = teamMemberRepository;
		}

		public async Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync() => await _teamMemberRepository.GetAllAsync();
		public async Task<TeamMember> GetTeamMemberByIdAsync(int id) => await _teamMemberRepository.GetByIdAsync(id);
		public async Task AddTeamMemberAsync(TeamMember memberDto) => await _teamMemberRepository.AddAsync(memberDto);
		public async Task UpdateTeamMemberAsync(int id, TeamMember memberDto)
		{
			var existing = await _teamMemberRepository.GetByIdAsync(id);
			if (existing != null)
			{
				await _teamMemberRepository.UpdateAsync(memberDto);
			}
		}
		public async Task DeleteTeamMemberAsync(int id) => await _teamMemberRepository.DeleteAsync(id);
	}

}
