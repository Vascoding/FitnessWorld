using FitnessWorld.Data.ViewModels.WorkoutModels;
using FitnessWorld.Services.Models.WorkoutModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutServiceModel>> AllAsync(int page = 1);

        Task<IEnumerable<WorkoutServiceModel>> AllResult(string searchText);

        Task AddAsync(string name, string description, string videoId);

        Task<WorkoutCrudModel> FindAsync(int id);

        Task EditAsync(int id, string name, string description, string videoId);

        Task<bool> DeleteAsync(int id);

        Task<int> TotalAsync();

        Task<IEnumerable<WorkoutServiceModel>> LastAddedAsync();
    }
}
