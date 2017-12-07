using System;
using System.Collections.Generic;

namespace FitnessWorld.Web.Models.ListingViewModels
{
    public class ListingModel
    {
        public IEnumerable<object> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalItems / 3);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
