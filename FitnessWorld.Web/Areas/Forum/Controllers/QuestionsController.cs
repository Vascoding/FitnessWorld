using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.QuestionModels;
using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    public class QuestionsController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IQuestionService questions;

        public QuestionsController(UserManager<User> userManager, IQuestionService questions)
        {
            this.userManager = userManager;
            this.questions = questions;
        }

        public async Task<IActionResult> AllInCategory(int id)
            => this.View(await this.questions.AllInCategoryAsync(id));

        public IActionResult Ask(int id)
        {
            var userId = this.userManager.GetUserId(User);

            return this.View(new QuestionViewModel { CategoryId = id, UserId = userId });
        }

        [HttpPost]
        public async Task<IActionResult> Ask(QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(HomeController.Index));
            }

            await this.questions.Create(model.Title, model.Content, model.CategoryId, model.UserId);

            return this.RedirectToAction(nameof(AllInCategory), new { id = model.CategoryId });
        }
    }
}
