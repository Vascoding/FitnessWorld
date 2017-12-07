using FitnessWorld.Data.ViewModels.FoodModels;
using FitnessWorld.Services.Models.FoodModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodServiceModel>> AllAsync(int page = 1);

        Task Create(string name, int calories, int fat, int proteins, int carbs, int fiber, int sugar);

        Task<FoodCrudModel> FindByIdAsync(int id);

        Task EditAsync(int id, string name, int calories, int fat, int proteins, int carbs, int fiber, int sugar);

        Task DeleteAsync(int id);

        Task<int> TotalAsync();
    }
}
