using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.FoodModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly FitnessWorldDbContext db;

        public FoodService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<FoodServiceModel>> AllAsync()
        => await this.db.Food
            .ProjectTo<FoodServiceModel>()
            .ToListAsync();

        public async Task Create(string name, int calories, int fat, int proteins, int carbs, int fiber, int sugar)
        {
            var food = new Food()
            {
                Name = name,
                Calories = calories,
                Fat = fat,
                Protein = proteins,
                Carbs = carbs,
                Fiber = fiber,
                Sugar = sugar
            };

            this.db.Food.Add(food);

            await this.db.SaveChangesAsync();
        }
    }
}
