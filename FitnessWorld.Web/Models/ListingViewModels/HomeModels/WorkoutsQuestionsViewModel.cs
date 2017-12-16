using FitnessWorld.Services.Models.QuestionModels;
using FitnessWorld.Services.Models.WorkoutModels;
using System.Collections.Generic;

namespace FitnessWorld.Web.Models.ListingViewModels.HomeModels
{
    public class WorkoutsQuestionsViewModel
    {
        public IEnumerable<QuestionServiceModel> Questions { get; set; }

        public IEnumerable<WorkoutServiceModel> Workouts { get; set; }
    }
}
