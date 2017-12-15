using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.WorkoutModels
{
    using static DataConstants;

    public class WorkoutViewModel
    {
        [Required]
        [MinLength(WorkoutNameMinLength)]
        [MaxLength(WorkoutNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(NutritionDescriptionMinLength)]
        [MaxLength(NutritionDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(VieoIdMinLength)]
        [MaxLength(VieoIdMaxLength)]
        [Display(Name = "https//www.youtube.com/?v=")]
        public string VideoId { get; set; }
    }
}
