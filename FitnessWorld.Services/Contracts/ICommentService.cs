using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface ICommentService
    {
        Task<int> CreateAsync(string content, string userId, int answerId);
    }
}
