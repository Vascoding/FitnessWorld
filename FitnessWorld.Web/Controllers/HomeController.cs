using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessWorld.Web.Models;
using FitnessWorld.Web.Models.ListingViewModels.HomeModels;
using FitnessWorld.Services.Contracts;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService questions;
        private readonly IWorkoutService workouts;

        public HomeController(IQuestionService questions, IWorkoutService workouts)
        {
            this.questions = questions;
            this.workouts = workouts;
        }

        public async Task<IActionResult> Index()
            => this.View(new WorkoutsQuestionsViewModel
            {
                Questions = await this.questions.LastAddedAsync(),
                Workouts = await this.workouts.LastAddedAsync()
            });

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
