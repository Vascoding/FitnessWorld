using FitnessWorld.Data.ViewModels.WorkoutModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.WorkoutModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Admin.Controllers
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
                return this.RedirectToAction(nameof(Index));
            }

            await this.workouts.AddAsync(model.Name, model.Description, model.VideoId);

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
                return this.RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            await this.workouts.EditAsync(model.Id, model.Name, model.Description, model.VideoId);

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
            await this.workouts.DeleteAsync(id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
