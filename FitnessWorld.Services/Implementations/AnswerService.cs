using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.AnswerModels;
using FitnessWorld.Services.Models.CommentModels;
using FitnessWorld.Services.Models.QuestionModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly FitnessWorldDbContext db;

        public AnswerService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string content, string userId, int questionId)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
            var question = this.db.Questions.FirstOrDefault(q => q.Id == questionId);

            if (user != null && question != null && !question.UserId.Contains(userId))
            {
                this.db.Answers.Add(new Answer
                {
                    Content = content,
                    UserId = userId,
                    QuestionId = questionId,
                    Published = DateTime.UtcNow
                });
                user.Points++;
                await this.db.SaveChangesAsync();
            }

        }

        public async Task<ListAnswersServiceModel> AllInQuestionAsync(int id)
        {
            var questionid = id;
            var categoryId = this.db.Questions.FirstOrDefault(q => q.Id == id).CategoryId;
            var questions = await this.db.Questions.Where(q => q.Id == id).ProjectTo<QuestionServiceModel>().FirstOrDefaultAsync();
            var answers = await this.db.Answers.Where(q => q.QuestionId == id).ProjectTo<AnswerServiceModel>().ToListAsync();

            foreach (var answer in answers)
            {
                answer.Comments = await this.db.Comments.Where(c => c.AnswerId == answer.Id).ProjectTo<CommentServiceModel>().ToListAsync();
            }

            return new ListAnswersServiceModel
            {
                QuestionId = questionid,
                CategoryId = categoryId,
                Question = questions,
                Answers = answers
            };
        }
    }
}
