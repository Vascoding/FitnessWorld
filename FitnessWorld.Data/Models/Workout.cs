using System.ComponentModel.DataAnnotations;
using FitnessWorld.Data.Constants;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class Workout
    {
        public int Id { get; set; }

        [Required]
        [MinLength(WorkoutNameMinLength)]
        [MaxLength(WorkoutNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(WorkoutDescriptionMinLength)]
        [MaxLength(WorkoutDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(VieoIdMinLength)]
        [MaxLength(VieoIdMaxLength)]
        public string VideoId { get; set; }
    }
}
