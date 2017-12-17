using FitnessWorld.Data.ViewModels.CategoryModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Infrastructure.Constants;
using FitnessWorld.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController
    {
        private const string CreateCategorySuccessMessage = "You added category successfully!";
        private const string NotValidCategoryErrorMessage = "Category name is required and must be between 3 and 30 symbols";
        private const string EditCategorySuccessMessage = "You edited category successfully!";
        private const string DeleteCategorySuccessMessage = "You deleted category successfully!";

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
                TempData.AddErrorMessage(NotValidCategoryErrorMessage);
                return this.RedirectToAction(nameof(Create));
            }
            TempData.AddSuccessMessage(CreateCategorySuccessMessage);
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
                TempData.AddErrorMessage(NotValidCategoryErrorMessage);
                return this.RedirectToAction(nameof(Index));
            }

            await this.categories.Edit(model.Id, model.Name);
            TempData.AddSuccessMessage(EditCategorySuccessMessage);
            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
            => this.View(await this.categories.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            var success = await this.categories.DeleteAsync(id);
            if (success)
            {
                TempData.AddSuccessMessage(DeleteCategorySuccessMessage);
                return this.RedirectToAction(nameof(Index));
            }

            TempData.AddErrorMessage(WebConstants.NotFound);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
