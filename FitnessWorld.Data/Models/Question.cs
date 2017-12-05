using FitnessWorld.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class Question
    {
        public int Id { get; set; }

        [Required]
        [MinLength(QuestionTitleMinLength)]
        [MaxLength(QuestionTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(QuestionContentMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime Published { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
