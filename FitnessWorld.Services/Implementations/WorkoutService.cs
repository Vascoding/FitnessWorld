using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.WorkoutModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.WorkoutModels;
using FitnessWorld.Services.Constants;

namespace FitnessWorld.Services.Implementations
{
    public class WorkoutService : IWorkoutService
    {
        private readonly FitnessWorldDbContext db;

        public WorkoutService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<WorkoutServiceModel>> AllAsync(int page = 1)
            => await this.db
             .Workouts
             .Skip((page - 1) * ServiceConstants.WorkoutPageSize)
             .Take(ServiceConstants.WorkoutPageSize)
             .ProjectTo<WorkoutServiceModel>()
             .ToListAsync();

        public async Task<IEnumerable<WorkoutServiceModel>> AllResult(string searchText)
            =>  await this.db
                .Workouts
                .Where(w => w.Name.ToLower().Contains(searchText.ToLower()) || w.Description.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<WorkoutServiceModel>()
                .ToListAsync();


        public async Task AddAsync(string name, string description, string videoId)
        {
            var workout = new Workout
            {
                Name = name,
                Description = description,
                VideoId = videoId
            };

            await this.db.Workouts.AddAsync(workout);
            await this.db.SaveChangesAsync();
        }

        public async Task<WorkoutCrudModel> FindAsync(int id)
            => await this.db
            .Workouts
            .Where(w => w.Id == id)
            .ProjectTo<WorkoutCrudModel>()
            .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string name, string description, string videoId)
        {
            var workout = await this.db.Workouts.FirstOrDefaultAsync(w => w.Id == id);

            if (workout != null)
            {
                workout.Name = name;
                workout.Description = description;
                workout.VideoId = videoId;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var workout = await this.db.Workouts.FirstOrDefaultAsync(w => w.Id == id);

            if (workout != null)
            {
                this.db.Workouts.Remove(workout);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WorkoutServiceModel>> LastAddedAsync()
            => await this.db
            .Workouts
            .OrderByDescending(w => w.Id)
            .Take(ServiceConstants.LastAddedWorkouts)
            .ProjectTo<WorkoutServiceModel>()
            .ToListAsync();

        public async Task<int> TotalAsync() => await this.db.Workouts.CountAsync();
    }
}
