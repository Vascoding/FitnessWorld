using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.CommentModels;
using FitnessWorld.Services.Contracts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CommentCrudModel> FindAsync(int id) 
            => await this.db
            .Comments
            .Where(c => c.Id == id)
            .ProjectTo<CommentCrudModel>()
            .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string content, string userId)
        {
            var comment = await this.db.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment != null && comment.UserId == userId)
            {
                comment.Content = content;
                comment.Published = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var comment = await this.db.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment != null && comment.UserId == userId)
            {
                this.db.Comments.Remove(comment);

                await this.db.SaveChangesAsync();
            }
        }
    }
}
