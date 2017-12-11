﻿using FitnessWorld.Data.Constants;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<UserFood> Food { get; set; } = new List<UserFood>();

        public List<UserResponder> MainUsers { get; set; } = new List<UserResponder>();

        public List<UserResponder> Responders { get; set; } = new List<UserResponder>();

        [Range(0, int.MaxValue)]
        public int Points { get; set; }
    }
}
