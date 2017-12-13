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

        public async Task<IActionResult> Edit(int id)
            => this.View(await this.questions.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(QuestionCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            await this.questions.EditAsync(model.Id, model.Title, model.Content, this.GetUserId());

            return this.RedirectToAction(nameof(AllInCategory), new { id = model.CategoryId });
        }


        public async Task<IActionResult> Delete(int id)
            => this.View(await this.questions.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Delete(QuestionCrudModel model)
        {

            await this.questions.Delete(model.Id, this.GetUserId());

            return this.RedirectToAction(nameof(AllInCategory), new { id = model.CategoryId });
        }

        private string GetUserId()
        {
            return this.userManager.GetUserId(User);
        }
    }
}
