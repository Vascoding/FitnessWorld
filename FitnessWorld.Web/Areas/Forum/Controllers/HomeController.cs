using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Forum.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryService categories;

        public HomeController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Index() => this.View(await this.categories.AllAsync());
    }
}
