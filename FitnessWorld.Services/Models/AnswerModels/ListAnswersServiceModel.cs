using FitnessWorld.Services.Models.CommentModels;
using FitnessWorld.Services.Models.QuestionModels;
using System.Collections.Generic;

namespace FitnessWorld.Services.Models.AnswerModels
{
    public class ListAnswersServiceModel
    {
        public int QuestionId { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<AnswerServiceModel> Answers { get; set; }

        public QuestionServiceModel Question { get; set; }
    }
}
