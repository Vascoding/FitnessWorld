using FitnessWorld.Services.Models.QuestionModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IQuestionService
    {
        Task Create(string title, string content, int categoryId, string userId);

        Task<ListQuestionsServiceModel> AllInCategoryAsync(int id);
    }
}
