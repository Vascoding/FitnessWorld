using FitnessWorld.Data.ViewModels.FoodModels;
using FitnessWorld.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Admin.Controllers
{
    public class FoodController : BaseController
    {
        private readonly IFoodService food;

        public FoodController(IFoodService food)
        {
            this.food = food;
        }

        public async Task<IActionResult> Index() => this.View(await this.food.AllAsync());

        public IActionResult Add() => this.View();

        [HttpPost]
        public async Task<IActionResult> Add(FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Add));
            }

            await this.food.Create(model.Name, model.Calories, model.Fat, model.Protein, model.Carbs, model.Fiber, model.Sugar);

            return this.RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Edit(int id) 
            => this.View(await this.food.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Edit(FoodCrudModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Edit));
            }

            await this.food.EditAsync(model.Id, model.Name, model.Calories, model.Fat, model.Protein, model.Carbs, model.Fiber, model.Sugar);
            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
           => this.View(await this.food.FindByIdAsync(id));

        public async Task<IActionResult> Confirm(int id)
        {
            await this.food.DeleteAsync(id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
