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
	public class HolidayService : IHolidayService
	{
		private readonly IHolidayRepository _holidayRepository;

		public HolidayService(IHolidayRepository holidayRepository)
		{
			_holidayRepository = holidayRepository;
		}

		public async Task<IEnumerable<Holiday>> GetAllHolidaysAsync() => await _holidayRepository.GetAllAsync();
		public async Task<Holiday> GetHolidayByIdAsync(int id) => await _holidayRepository.GetByIdAsync(id);
		public async Task AddHolidayAsync(Holiday holidayDto) => await _holidayRepository.AddAsync(holidayDto);
		public async Task UpdateHolidayAsync(int id, Holiday holidayDto)
		{
			var existing = await _holidayRepository.GetByIdAsync(id);
			if (existing != null)
			{
				await _holidayRepository.UpdateAsync(holidayDto);
			}
		}
		public async Task DeleteHolidayAsync(int id) => await _holidayRepository.DeleteAsync(id);
	}

}
