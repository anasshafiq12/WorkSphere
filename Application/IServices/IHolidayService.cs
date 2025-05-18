using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IHolidayService
	{
		Task<IEnumerable<Holiday>> GetAllHolidaysAsync();
		Task<Holiday> GetHolidayByIdAsync(int id);
		Task AddHolidayAsync(Holiday holidayDto);
		Task UpdateHolidayAsync(int id, Holiday holidayDto);
		Task DeleteHolidayAsync(int id);
	}

}
