using System;
using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.QuestionModels
{
    using static DataConstants;

    public class QuestionViewModel
    {
        [Required]
        [MinLength(QuestionTitleMinLength)]
        [MaxLength(QuestionTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(QuestionContentMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public DateTime Published { get; set; }
    }
}
