using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Web.Infrastructure.Constants;
using FitnessWorld.Web.Infrastructure.Extensions;
using FitnessWorld.Web.Models.ListingViewModels.CalculatorModels;
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

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return this.View(new ListCalculateViewModel
                {
                    Food = await this.food.AllAsync(page),
                    TotalFoodCount = await this.food.TotalAsync(),
                    Calculator = await this.calculator.FoodToCalculate(userManager.GetUserId(User)),
                    CurrentPage = page
                });
            }

            this.ViewData.AddSearchMessage(string.Format(WebConstants.ViewDataSearchResultMessage, searchText));

            return this.View(new ListCalculateViewModel
            {
                Food = await this.food.ResultAsync(searchText),
                Calculator = await this.calculator.FoodToCalculate(userManager.GetUserId(User)),
                CurrentPage = page
            });
        }

        public async Task<IActionResult> Add(int id)
        {
            var model = await this.calculator.Find(id);

            if (model != null)
            {
                return this.View(model);
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            var userId = this.userManager.GetUserId(User);

            await this.calculator.Add(id, userId, quantity);

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
