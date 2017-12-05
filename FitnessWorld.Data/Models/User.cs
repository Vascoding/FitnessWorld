using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitnessWorld.Data.Models
{
    public class User : IdentityUser
    {
        public List<Question> Questions { get; set; } = new List<Question>();

        public List<Answer> Answers { get; set; } = new List<Answer>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<UserFood> Food { get; set; } = new List<UserFood>();

        public int Points { get; set; }
    }
}
