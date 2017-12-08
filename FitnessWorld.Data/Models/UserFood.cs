namespace FitnessWorld.Data.Models
{
    public class UserFood
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }
    }
}
