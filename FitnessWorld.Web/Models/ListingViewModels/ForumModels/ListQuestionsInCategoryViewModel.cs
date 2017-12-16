using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Models.QuestionModels;
using System;
using System.Linq;

namespace FitnessWorld.Web.Models.ListingViewModels.ForumModels
{
    public class ListQuestionsInCategoryViewModel
    {
        public ListQuestionsServiceModel Questions { get; set; }

        public int TotalQuestionsCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalQuestionsCount / ServiceConstants.QuestionsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
