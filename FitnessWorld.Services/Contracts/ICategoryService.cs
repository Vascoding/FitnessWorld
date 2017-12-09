using FitnessWorld.Data.ViewModels.CategoryModels;
using FitnessWorld.Services.Models.CategoriesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface ICategoryService
    {
        Task Create(string name);

        Task<IEnumerable<CategoryServiceModel>> AllAsync();

        Task<CategoryCrudModel> FindByIdAsync(int id);

        Task Edit(int id, string name);

        Task Delete(int id);
    }
}
