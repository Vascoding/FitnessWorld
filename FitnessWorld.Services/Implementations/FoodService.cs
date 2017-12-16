using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.FoodModels;
using FitnessWorld.Services.Constants;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.FoodModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<FoodServiceModel>> AllAsync(int page = 1)
        => await this.db.Food
            .Skip((page - 1) * ServiceConstants.FoodPageSize)
            .Take(ServiceConstants.FoodPageSize)
            .ProjectTo<FoodServiceModel>()
            .ToListAsync();

        public async Task<IEnumerable<FoodServiceModel>> ResultAsync(string searchText)
        => await this.db.Food
            .Where(f => f.Name.ToLower().Contains(searchText.ToLower()))
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

        public async Task<FoodCrudModel> FindByIdAsync(int id)
            => await this.db
            .Food
            .Where(f => f.Id == id)
            .ProjectTo<FoodCrudModel>()
            .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string name, int calories, int fat, int protein, int carbs, int fiber, int sugar)
        {
            var food = await this.db.Food.FirstOrDefaultAsync(f => f.Id == id);

            if (food != null)
            {
                food.Name = name;
                food.Calories = calories;
                food.Fat = fat;
                food.Protein = protein;
                food.Carbs = carbs;
                food.Fiber = fiber;
                food.Sugar = sugar;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var food = await this.db.Food.FirstOrDefaultAsync(f => f.Id == id);

            if (food != null)
            {
                this.db.Food.Remove(food);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task<int> TotalAsync() => await this.db.Food.CountAsync();
    }
}
