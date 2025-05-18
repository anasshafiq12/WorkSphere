using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface ITeamMemberRepository
	{
		Task<IEnumerable<TeamMember>> GetAllAsync();
		Task<TeamMember?> GetByIdAsync(int id);
		Task AddAsync(TeamMember teamMember);
		Task UpdateAsync(TeamMember teamMember);
		Task DeleteAsync(int id);
	}
}
