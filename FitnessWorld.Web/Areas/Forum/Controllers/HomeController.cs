using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.ForumModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryService categories;
        private readonly IQuestionService questions;

        public HomeController(ICategoryService categories, IQuestionService questions)
        {
            this.categories = categories;
            this.questions = questions;
        }

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return this.View(new ListQuestionsViewModel
                {
                    Categories = await this.categories.AllAsync(),
                    Questions = await this.questions.AllAsync(page),
                    TotalQuestionsCount = await this.questions.TotalAsync(),
                    CurrentPage = page
                });
            }

            return this.View(new ListQuestionsViewModel
            {
                Categories = await this.categories.AllAsync(),
                Questions = await this.questions.ResultAsync(searchText)
            });
        }
    }
}
