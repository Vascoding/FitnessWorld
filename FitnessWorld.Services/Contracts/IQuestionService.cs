using FitnessWorld.Data.ViewModels.QuestionModels;
using FitnessWorld.Services.Models.QuestionModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IQuestionService
    {
        Task Create(string title, string content, int categoryId, string userId);

        Task<ListQuestionsServiceModel> AllInCategoryAsync(int id);

        Task<QuestionCrudModel> FindAsync(int id);

        Task EditAsync(int id, string title, string content, string userId);

        Task Delete(int id, string userId);

        Task<IEnumerable<QuestionServiceModel>> ResultAsync(string searchText);

        Task<IEnumerable<QuestionServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();
    }
}
