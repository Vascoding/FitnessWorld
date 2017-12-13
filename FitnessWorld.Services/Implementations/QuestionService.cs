using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.QuestionModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.QuestionModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly FitnessWorldDbContext db;

        public QuestionService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task Create(string title, string content, int categoryId, string userId)
        {
            if (this.db.Categories.FirstOrDefault(c => c.Id == categoryId) != null && 
                this.db.Users.FirstOrDefault(u => u.Id == userId) != null)
            {
                var question = new Question
                {
                    Title = title,
                    Content = content,
                    Published = DateTime.UtcNow,
                    CategoryId = categoryId,
                    UserId = userId
                };

                await this.db.Questions.AddAsync(question);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<ListQuestionsServiceModel> AllInCategoryAsync(int id)
            => new ListQuestionsServiceModel
            {
                CategoryId = id,
                Questions = await this.db
                .Questions
                .Where(q => q.CategoryId == id)
                .OrderByDescending(q => q.Published)
                .ProjectTo<QuestionServiceModel>()
                .ToListAsync()
            };

        public async Task<QuestionCrudModel> FindAsync(int id)
            => await this.db
            .Questions
            .Where(q => q.Id == id)
            .ProjectTo<QuestionCrudModel>()
            .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string title, string content, string userId)
        {
            var question = await this.db.Questions.Where(q => q.Id == id).FirstOrDefaultAsync();

            if (question != null && question.UserId == userId) 
            {
                question.Title = title;
                question.Content = content;
                question.Published = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id, string userId)
        {
            var question = await this.db.Questions.FirstOrDefaultAsync(q => q.Id == id);

            if (question != null && question.UserId == userId)
            {
                this.db.Remove(question);

                await this.db.SaveChangesAsync();
            }
        }
    }
}
