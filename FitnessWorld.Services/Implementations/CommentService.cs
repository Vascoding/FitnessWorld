using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly FitnessWorldDbContext db;

        public CommentService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(string content, string userId, int answerId)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
            var answer = this.db.Answers.FirstOrDefault(a => a.Id == answerId);

            if (user != null && answer != null)
            {
                var comment = new Comment
                {
                    Content = content,
                    UserId = userId,
                    AnswerId = answerId,
                    Published = DateTime.UtcNow
                };

                await this.db.Comments.AddAsync(comment);
                await this.db.SaveChangesAsync();
            }

            return answer.QuestionId;
        }
    }
}
