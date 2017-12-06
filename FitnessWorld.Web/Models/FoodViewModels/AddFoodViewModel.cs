using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Web.Models.FoodViewModels
{
    public class AddFoodViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Range(0, int.MaxValue)]
        public int Fat { get; set; }

        [Range(0, int.MaxValue)]
        public int Protein { get; set; }

        [Range(0, int.MaxValue)]
        public int Carbs { get; set; }

        [Range(0, int.MaxValue)]
        public int Fiber { get; set; }

        [Range(0, int.MaxValue)]
        public int Sugar { get; set; }
    }
}
