using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Models.ListingViewModels.CalculatorModels;
using FitnessWorld.Web.Models.ListingViewModels.FoodModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Areas.Calculator.Controllers
{
    public class CalculateController : BaseController
    {
        private readonly IFoodService food;
        private readonly ICalculatorService calculator;
        private readonly UserManager<User> userManager;

        public CalculateController(IFoodService food, UserManager<User> userManager, ICalculatorService calculator)
        {
            this.food = food;
            this.userManager = userManager;
            this.calculator = calculator;
        }

        public async Task<IActionResult> Index(int page = 1) => this.View(new ListCalculateViewModel
        {
            Food = await this.food.AllAsync(page),
            TotalFoodCount = await this.food.TotalAsync(),
            Calculator = await this.calculator.FoodToCalculate(userManager.GetUserId(User)),
            CurrentPage = page
        });

        public async Task<IActionResult> Add(int id)
        {
            var userId = this.userManager.GetUserId(User);

            await this.calculator.Add(id, userId);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var userId = this.userManager.GetUserId(User);

            await this.calculator.Remove(id, userId);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
