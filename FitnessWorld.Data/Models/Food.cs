﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ServingSize { get; set; } = 100;

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

        public List<UserFood> Users { get; set; } = new List<UserFood>();
    }
}
