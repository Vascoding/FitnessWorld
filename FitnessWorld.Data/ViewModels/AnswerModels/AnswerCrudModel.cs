using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.AnswerModels
{
    using FitnessWorld.Common.Mapping.Contracts;
    using FitnessWorld.Data.Models;
    using static DataConstants;

    public class AnswerCrudModel : IMapFrom<Answer>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Content { get; set; }

        public int QuestionId { get; set; }
    }
}
