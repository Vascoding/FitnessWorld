using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.WorkoutModels
{
    using FitnessWorld.Common.Mapping.Contracts;
    using FitnessWorld.Data.Models;
    using static DataConstants;

    public class WorkoutCrudModel : IMapFrom<Workout>
    {
        public int Id { get; set; }

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
        public string VideoId { get; set; }
    }
}
