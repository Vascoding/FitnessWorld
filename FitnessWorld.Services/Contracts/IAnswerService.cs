using FitnessWorld.Data.ViewModels.AnswerModels;
using FitnessWorld.Services.Models.AnswerModels;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IAnswerService
    {
        Task CreateAsync(string content, string userId, int questionId);

        Task<ListAnswersServiceModel> AllInQuestionAsync(int id);

        Task<AnswerCrudModel> FindAsync(int id);

        Task EditAsync(int id, string content, string userId);

        Task DeleteAsync(int id, string userId);

        Task BestAnswer(int id, string userId, int questionId);
    }
}
