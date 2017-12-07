using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Models.CalculatorModels;
using FitnessWorld.Services.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Models.ListingViewModels.CalculatorModels
{
    public class ListCalculateViewModel
    {
        public IEnumerable<FoodServiceModel> Food { get; set; }

        public IEnumerable<CalculatorServiceModel> Calculator { get; set; }

        public int TotalFoodCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalFoodCount / ServiceConstants.PageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
