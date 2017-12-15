using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Models.WorkoutModels;
using System;
using System.Collections.Generic;

namespace FitnessWorld.Web.Models.ListingViewModels.WorkoutModels
{
    public class ListWorkoutModel
    {
        public IEnumerable<WorkoutServiceModel> Workout { get; set; }

        public int TotalWorkoutCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalWorkoutCount / ServiceConstants.PageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
