using System.Collections.Generic;

namespace FitnessWorld.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ServingSize { get; set; } = 100;

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fiber { get; set; }
        
        public int Sugar { get; set; }

        public List<UserFood> Users { get; set; }
    }
}
