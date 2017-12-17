using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Infrastructure.Constants;
using FitnessWorld.Web.Infrastructure.Extensions;
using FitnessWorld.Web.Models.ListingViewModels.WorkoutModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Trainings.Controllers
{
    public class WorkoutsController : BaseController
    {
        private readonly IWorkoutService workouts;

        public WorkoutsController(IWorkoutService workouts)
        {
            this.workouts = workouts;
        }

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return this.View(new ListWorkoutModel
                {
                    Workout = await this.workouts.AllAsync(page),
                    CurrentPage = page,
                    TotalWorkoutCount = await this.workouts.TotalAsync()
                });
            }

            this.ViewData.AddSearchMessage(string.Format(WebConstants.ViewDataSearchResultMessage, searchText));

            return this.View(new ListWorkoutModel
            {
                Workout = await this.workouts.AllResult(searchText)
            });
        }
    }
}
