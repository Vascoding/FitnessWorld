using System.Collections.Generic;

namespace FitnessWorld.Services.Models.QuestionModels
{
    public class ListQuestionsServiceModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<QuestionServiceModel> Questions { get; set; }
    }
}
