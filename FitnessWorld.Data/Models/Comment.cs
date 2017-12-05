using FitnessWorld.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

        public DateTime Published { get; set; }
    }
}
