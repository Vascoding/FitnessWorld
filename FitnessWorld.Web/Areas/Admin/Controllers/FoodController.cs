using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.FoodViewModels;
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
        public async Task<IActionResult> Add(AddFoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Add));
            }

            await this.food.Create(model.Name, model.Calories, model.Fat, model.Protein, model.Carbs, model.Fiber, model.Sugar);

            return this.RedirectToAction(nameof(Add)); 
        }
    }
}
