using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.Models
{
    using static DataConstants;

    public class UserFood
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        [Required]
        [Range(UserFoodMinQuantity, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
