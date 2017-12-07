using FitnessWorld.Services.Models.CalculatorModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface ICalculatorService
    {
        Task Add(int foodId, string userId);

        Task Remove(int foodId, string userId);

        Task<IEnumerable<CalculatorServiceModel>> FoodToCalculate(string userId);
    }
}
