using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface ITeamMemberService
	{
		Task<IEnumerable<TeamMember>> GetAllTeamMembersAsync();
		Task<TeamMember> GetTeamMemberByIdAsync(int id);
		Task AddTeamMemberAsync(TeamMember memberDto);
		Task UpdateTeamMemberAsync(int id, TeamMember memberDto);
		Task DeleteTeamMemberAsync(int id);
	}

}
