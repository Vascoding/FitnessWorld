using FitnessWorld.Data.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.AnswerModels
{
    using static DataConstants;
    public class AnswerViewModel
    {
        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int QuestionId { get; set; }

        public DateTime Published { get; set; }
    }
}
