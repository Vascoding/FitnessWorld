using FitnessWorld.Data.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.Models
{
    using System;
    using static DataConstants;

    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int QuestionId { get; set; }

        public bool IsBestAnswer { get; set; }

        public Question Question { get; set; }

        public DateTime Published { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
