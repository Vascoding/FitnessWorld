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

        Task EditAsync(int id, string title, string content);

        Task Delete(int id);
    }
}
