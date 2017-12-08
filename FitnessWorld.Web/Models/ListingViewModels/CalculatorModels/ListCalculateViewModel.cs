using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Models.CalculatorModels;
using FitnessWorld.Services.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessWorld.Web.Models.ListingViewModels.CalculatorModels
{
    public class ListCalculateViewModel
    {
        public IEnumerable<FoodServiceModel> Food { get; set; }

        public IEnumerable<CalculatorServiceModel> Calculator { get; set; }

        public CalculatorServiceModel Total
        {
            get
            {
                return this.Calculate();
            }
        } 

        public int TotalFoodCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalFoodCount / ServiceConstants.PageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;

        

        private CalculatorServiceModel Calculate()
        {
            return new CalculatorServiceModel
            {
                Calories = this.Calculator.Sum(c => c.Calories),
                Carbs = this.Calculator.Sum(c => c.Carbs),
                Fat = this.Calculator.Sum(f => f.Fat),
                Fiber = this.Calculator.Sum(f => f.Fiber),
                Protein = this.Calculator.Sum(p => p.Protein),
                Sugar = this.Calculator.Sum(s => s.Sugar)
            };
        }
    }
}
