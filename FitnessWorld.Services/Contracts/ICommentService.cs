using FitnessWorld.Data.ViewModels.CommentModels;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Contracts
{
    public interface ICommentService
    {
        Task<int> CreateAsync(string content, string userId, int answerId);

        Task<CommentCrudModel> FindAsync(int id);

        Task EditAsync(int id, string content, string userId);

        Task DeleteAsync(int id, string userId);
    }
}
