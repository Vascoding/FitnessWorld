using FitnessWorld.Data.ViewModels.FoodModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.FoodModels;
using FitnessWorld.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FitnessWorld.Web.Infrastructure.Constants;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class FoodController : BaseController
    {
        private const string CreateFoodSuccessMessage = "You added food successfully!";
        private const string NotValidFoodErrorMessage = "Food characteristics must be non negative";
        private const string EditFoodSuccessMessage = "You edited food successfully!";
        private const string DeleteFoodSuccessMessage = "You deleted food successfully!";

        private readonly IFoodService food;

        public FoodController(IFoodService food)
        {
            this.food = food;
        }

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return this.View(new ListFoodViewModel
                {
                    Food = await this.food.AllAsync(page),
                    TotalFoodCount = await this.food.TotalAsync(),
                    CurrentPage = page
                });
            }

            ViewData.AddSearchMessage(string.Format(WebConstants.ViewDataSearchResultMessage, searchText));

            return this.View(new ListFoodViewModel
            {
                Food = await this.food.ResultAsync(searchText),
                CurrentPage = page
            });
        }

        public IActionResult Add() => this.View();

        [HttpPost]
        public async Task<IActionResult> Add(FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(NotValidFoodErrorMessage);
                return this.RedirectToAction(nameof(Add));
            }

            await this.food.Create(model.Name, model.Calories, model.Fat, model.Protein, model.Carbs, model.Fiber, model.Sugar);
            TempData.AddSuccessMessage(CreateFoodSuccessMessage);

            return this.RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Edit(int id) 
            => this.View(await this.food.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(FoodCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(NotValidFoodErrorMessage);
                return this.RedirectToAction(nameof(Edit));
            }

            await this.food.EditAsync(model.Id, model.Name, model.Calories, model.Fat, model.Protein, model.Carbs, model.Fiber, model.Sugar);
            TempData.AddSuccessMessage(EditFoodSuccessMessage);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
           => this.View(await this.food.FindByIdAsync(id));

        public async Task<IActionResult> Confirm(int id)
        {
            var success = await this.food.DeleteAsync(id);

            if (success)
            {
                TempData.AddSuccessMessage(DeleteFoodSuccessMessage);
                return this.RedirectToAction(nameof(Index));
            }

            TempData.AddErrorMessage(WebConstants.NotFound);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
