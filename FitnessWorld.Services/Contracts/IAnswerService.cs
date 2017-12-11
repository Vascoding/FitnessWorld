using FitnessWorld.Services.Models.AnswerModels;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface IAnswerService
    {
        Task CreateAsync(string content, string userId, int questionId);

        Task<ListAnswersServiceModel> AllInQuestionAsync(int id);
    }
}
