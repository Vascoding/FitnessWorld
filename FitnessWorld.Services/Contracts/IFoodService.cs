using FitnessWorld.Services.Models.FoodModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodServiceModel>> AllAsync();

        Task Create(string name, int calories, int fat, int proteins, int carbs, int fiber, int sugar);
    }
}
