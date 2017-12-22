using AutoMapper;
using Xunit;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using FitnessWorld.Services.Implementations;
using FitnessWorld.Tests.Infrastructure;
using FitnessWorld.Data.Models;
using System.Linq;
using FitnessWorld.Common.Mapping;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.QuestionModels;
using System.Collections.Generic;

namespace FitnessWorld.Tests.Services
{
    public class QuestionServiceTest
    {
        private readonly DbSetup dbSetup;

        public QuestionServiceTest()
        {
            this.dbSetup = new DbSetup();
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        [Fact]
        public async Task ResultAsyncShouldReturnCorrectResultWithSearchTermAndOrder()
        {
            // Arrange

            var db = this.dbSetup.InitializeTestDb();

            var firstQuestion = new Question { Id = 1, Title = "First", Content = "maic" };
            var secondQuestion = new Question { Id = 2, Title = "Second", Content = "maic" };
            var thirdQuestion = new Question { Id = 3, Title = "Third", Content = "maic" };

            db.Questions.AddRange(firstQuestion, secondQuestion, thirdQuestion);

            await db.SaveChangesAsync();
         
            var questionService = new QuestionService(db);
            // Act

            var result = questionService.ResultAsync("t");
            // Assert

            result
                .Should()
                .Match(q => q.ElementAt(0).Id == 3
                && q.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }
    }
}
