using FitnessWorld.Data.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
