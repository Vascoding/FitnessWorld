using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.CommentModels;
using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly ICommentService comments;

        public CommentsController(UserManager<User> userManager, ICommentService comments)
        {
            this.userManager = userManager;
            this.comments = comments;
        }

        public IActionResult Create(int id)
        {
            var userId = userManager.GetUserId(User);

            return this.View(new CommentViewModel
            {
                AnswerId = id,
                UserId = userId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Create), new { id = model.AnswerId });
            }

            var questionid = await this.comments.CreateAsync(model.Content, model.UserId, model.AnswerId);

            return this.RedirectToAction(nameof(AnswersController.Index), "Answers", new { id = questionid });
        }

        public async Task<IActionResult> Edit(int id) 
            => this.View(await this.comments.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(CommentCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(AnswersController.Index), "Answers", new { id = model.QuestionId });
            }

            await this.comments.EditAsync(model.Id, model.Content, this.GetUserId());

            return this.RedirectToAction(nameof(AnswersController.Index), "Answers", new { id = model.QuestionId });
        }

        public async Task<IActionResult> Delete(int id)
          => this.View(await this.comments.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Delete(CommentCrudModel model)
        {
            await this.comments.DeleteAsync(model.Id, this.GetUserId());

            return this.RedirectToAction(nameof(AnswersController.Index), "Answers", new { id = model.QuestionId });
        }

        private string GetUserId()
        {
            return this.userManager.GetUserId(User);
        }
    }
}
