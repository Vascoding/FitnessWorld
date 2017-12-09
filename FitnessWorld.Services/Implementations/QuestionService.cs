using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.QuestionModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                Questions = await this.db.Questions.Where(q => q.CategoryId == id).ProjectTo<QuestionServiceModel>().ToListAsync()
            };

    }
}
