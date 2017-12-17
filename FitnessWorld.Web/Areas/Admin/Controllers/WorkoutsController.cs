using FitnessWorld.Data.ViewModels.WorkoutModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.WorkoutModels;
using FitnessWorld.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FitnessWorld.Web.Infrastructure.Constants;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class WorkoutsController : BaseController
    {
        private const string CreateWorkoutSuccessMessage = "You added workout successfully!";
        private const string NotValidWorkoutErrorMessage = "Name, descripton and videoid are required";
        private const string EditWorkoutSuccessMessage = "You edited workout successfully!";
        private const string DeleteWorkoutSuccessMessage = "You deleted workout successfully!";

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
            ViewData.AddSearchMessage(string.Format(WebConstants.ViewDataSearchResultMessage, searchText));
            return this.View(new ListWorkoutModel
            {
                Workout = await this.workouts.AllResult(searchText)
            });
        }

        public IActionResult Add()
            => this.View(new WorkoutViewModel());

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(NotValidWorkoutErrorMessage);
                return this.RedirectToAction(nameof(Index));
            }

            await this.workouts.AddAsync(model.Name, model.Description, model.VideoId);
            TempData.AddSuccessMessage(CreateWorkoutSuccessMessage);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.workouts.FindAsync(id);

            if (model == null)
            {
                return this.NotFound();
            }
            
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkoutCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(NotValidWorkoutErrorMessage);
                return this.RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            await this.workouts.EditAsync(model.Id, model.Name, model.Description, model.VideoId);
            TempData.AddSuccessMessage(EditWorkoutSuccessMessage);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.workouts.FindAsync(id);

            if (model == null)
            {
                return this.NotFound();
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            var success = await this.workouts.DeleteAsync(id);

            if (success)
            {
                TempData.AddErrorMessage(WebConstants.NotFound);
                return this.RedirectToAction(nameof(Index));
            }

            TempData.AddSuccessMessage(DeleteWorkoutSuccessMessage);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
