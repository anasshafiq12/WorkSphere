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
	public class ActivityService : IActivityService
	{
		private readonly IActivityRepository _activityRepository;

		public ActivityService(IActivityRepository activityRepository)
		{
			_activityRepository = activityRepository;
		}

		public async Task<IEnumerable<Activit>> GetAllActivitiesAsync()
		{
			return await _activityRepository.GetAllAsync();
		}

		public async Task<Activit?> GetActivityByIdAsync(int id)
		{
			return await _activityRepository.GetByIdAsync(id);
		}

		public async Task CreateActivityAsync(Activit activity)
		{
			await _activityRepository.AddAsync(activity);
		}

		public async Task UpdateActivityAsync(Activit activity)
		{
			await _activityRepository.UpdateAsync(activity);
		}

		public async Task DeleteActivityAsync(int id)
		{
			await _activityRepository.DeleteAsync(id);
		}
	}
}
