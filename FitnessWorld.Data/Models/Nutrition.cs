using FitnessWorld.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using FitnessWorld.Data.Constants;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class Nutrition
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NutritionNameMinLength)]
        [MaxLength(NutritionNameMaxLength)]
        public string Name { get; set; }

        [Range(0, NutritionQuantityMaxValue)]
        public int Quantity { get; set; }

        [Required]
        public double Portion { get; set; }

        [Required]
        [MinLength(NutritionDescriptionMinLength)]
        [MaxLength(NutritionDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Flavour Flavour { get; set; }
    }
}
