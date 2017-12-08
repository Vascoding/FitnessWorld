using FitnessWorld.Services.Models.CalculatorModels;
using FitnessWorld.Services.Models.FoodModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface ICalculatorService
    {
        Task Add(int foodId, string userId, int quantity);

        Task Remove(int foodId, string userId);

        Task<IEnumerable<CalculatorServiceModel>> FoodToCalculate(string userId);

        Task<FoodServiceModel> Find(int id);
    }
}
