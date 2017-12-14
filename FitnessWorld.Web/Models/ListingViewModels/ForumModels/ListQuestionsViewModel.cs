using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Models.CategoriesModels;
using FitnessWorld.Services.Models.QuestionModels;
using System;
using System.Collections.Generic;

namespace FitnessWorld.Web.Models.ListingViewModels.ForumModels
{
    public class ListQuestionsViewModel
    {
        public IEnumerable<QuestionServiceModel> Questions { get; set; }

        public IEnumerable<CategoryServiceModel> Categories { get; set; }

        public int TotalQuestionsCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalQuestionsCount / ServiceConstants.PageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
