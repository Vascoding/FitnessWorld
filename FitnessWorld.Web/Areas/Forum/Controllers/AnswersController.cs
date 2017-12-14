using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.AnswerModels;
using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    public class AnswersController : BaseController
    {
        private readonly IAnswerService answers;
        private readonly UserManager<User> userManager;

        public AnswersController(UserManager<User> userManager, IAnswerService answers)
        {
            this.userManager = userManager;
            this.answers = answers;
        }

        public async Task<IActionResult> Index(int id)
            => this.View(await this.answers.AllInQuestionAsync(id));

        public IActionResult Create(int id)
        {
            var userId = this.userManager.GetUserId(User);

            return this.View(new AnswerViewModel { QuestionId = id, UserId = userId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnswerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Index), new { id = model.QuestionId });
            }

            await this.answers.CreateAsync(model.Content, model.UserId, model.QuestionId);
            return this.RedirectToAction(nameof(Index), new { id = model.QuestionId });
        }

        public async Task<IActionResult> Edit(int id)
            => this.View(await this.answers.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(AnswerCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Index), new { id = model.QuestionId });
            }

            await this.answers.EditAsync(model.Id, model.Content, this.GetUserId());

            return this.RedirectToAction(nameof(Index), new { id = model.QuestionId });
        }

        public async Task<IActionResult> Delete(int id)
            => this.View(await this.answers.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Delete(AnswerCrudModel model)
        {
            await this.answers.DeleteAsync(model.Id, this.GetUserId());

            return this.RedirectToAction(nameof(Index), new { id = model.QuestionId });
        }

        [HttpPost]
        public async Task<IActionResult> BestAnswer(int answerId, int questionId)
        {
            await this.answers.BestAnswer(answerId, this.GetUserId(), questionId);

            return this.RedirectToAction(nameof(Index), new { id = questionId });
        }

        private string GetUserId()
        {
            return this.userManager.GetUserId(User);
        }
    }
}
