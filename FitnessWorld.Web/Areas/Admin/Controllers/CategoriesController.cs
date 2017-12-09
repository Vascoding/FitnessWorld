using FitnessWorld.Data.ViewModels.CategoryModels;
using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Index() 
            => this.View(await this.categories.AllAsync()); 

        public IActionResult Create() 
            => this.View(new CategoryViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Create));
            }

            await this.categories.Create(model.Name);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
            => this.View(await this.categories.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await this.categories.Edit(model.Id, model.Name);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
            => this.View(await this.categories.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            await this.categories.Delete(id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
