using FitnessWorld.Data.Constants;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorld.Data.Models
{
    
    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        public List<Answer> Answers { get; set; } = new List<Answer>();

        [NotMapped]
        public List<int> BestAnswers { get; set; } = new List<int>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<UserFood> Food { get; set; } = new List<UserFood>();

        [Range(0, int.MaxValue)]
        public int Points { get; set; }
    }
}
