using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.AnswerModels;
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

        public async Task<AnswerCrudModel> FindAsync(int id)
            => await this.db
            .Answers
            .Where(a => a.Id == id)
            .ProjectTo<AnswerCrudModel>()
            .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string content, string userId)
        {
            var answer = await this.db.Answers.FirstOrDefaultAsync(a => a.Id == id);

            if (answer != null && answer.UserId == userId)
            {
                answer.Content = content;
                answer.Published = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var answer = await this.db.Answers.FirstOrDefaultAsync(a => a.Id == id);

            if (answer != null && answer.UserId == userId)
            {
                this.db.Answers.Remove(answer);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task BestAnswer(int id, string userId, int questionId)
        {
            var answer = await this.db.Answers.FirstOrDefaultAsync(a => a.Id == id);
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var question = await this.db.Questions.FirstOrDefaultAsync(u => u.Id == questionId);
            var answers = await this.db.Answers.Where(a => a.QuestionId == questionId).ToListAsync();
            var userQuestion = this.db.Users.FirstOrDefault(u => u.Questions.FirstOrDefault(q => q.Id == question.Id) != null);
            var reciever = await this.db.Users.FirstOrDefaultAsync(u => u.Id == answer.UserId);

            if (answer != null && user != null && userQuestion != null && userQuestion == user && !answers.Any(a => a.IsBestAnswer))
            {
                answer.IsBestAnswer = true;
                reciever.Points += 10;

                await this.db.SaveChangesAsync();
            }
        }
    }
}
