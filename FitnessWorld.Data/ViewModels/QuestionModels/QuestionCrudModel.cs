using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.QuestionModels
{
    using FitnessWorld.Common.Mapping.Contracts;
    using FitnessWorld.Data.Models;

    public class QuestionCrudModel : IMapFrom<Question>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
