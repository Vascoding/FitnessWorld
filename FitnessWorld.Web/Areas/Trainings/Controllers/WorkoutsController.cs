using FitnessWorld.Services.Contracts;
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

        public async Task<IActionResult> Index()
            => this.View(await this.workouts.AllAsync());
    }
}
