using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.FoodModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IFoodService food;

        public CalculatorController(IFoodService food)
        {
            this.food = food;
        }

        public async Task<IActionResult> Index(int page = 1) => this.View(new ListFoodViewModel
        {
            Food = await this.food.AllAsync(page),
            TotalFoodCount = await this.food.TotalAsync(),
            CurrentPage = page
        });
    }
}
