﻿using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;

namespace FitnessWorld.Services.Models.FoodModels
{
    public class FoodServiceModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int ServingSize { get; set; } = 100;

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fiber { get; set; }

        public int Sugar { get; set; }
    }
}
