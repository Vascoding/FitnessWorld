using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.CalculatorModels;
using FitnessWorld.Services.Models.FoodModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        private readonly FitnessWorldDbContext db;

        public CalculatorService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task Add(int foodId, string userId, int quantity)
        {
            
            var userFood = await this.db.UserFood.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.FoodId == foodId);
            

            if (userFood == null)
            {
                var food = await this.db.Food.FirstOrDefaultAsync(f => f.Id == foodId);
                var user = await this.db.Users.FirstOrDefaultAsync(f => f.Id == userId);

                if (food != null && user != null)
                {
                    await this.db.UserFood.AddAsync(new UserFood
                    {
                        Food = food,
                        User = user,
                        FoodId = food.Id,
                        UserId = user.Id,
                        Quantity = quantity
                    });
                }
            }
            else
            {
                userFood.Quantity = quantity;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task Remove(int foodId, string userId)
        {

            var userFood = await this.db.UserFood.FirstOrDefaultAsync(u => u.UserId == userId && u.FoodId == foodId);
            if (userFood != null)
            {
                this.db.UserFood.Remove(userFood);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CalculatorServiceModel>> FoodToCalculate(string userId)
        {


            var foodToCalc = await this.db
            .Food
            .Where(f => f.Users.Any(u => u.UserId == userId))
            .ProjectTo<CalculatorServiceModel>()
            .ToListAsync();

            foreach (var food in foodToCalc)
            {
                food.Quantity = db.UserFood.FirstOrDefault(uf => uf.UserId == userId && uf.FoodId == food.Id).Quantity;
                food.Calories *= food.Quantity;
                food.Protein *= food.Quantity;
                food.Fat *= food.Quantity;
                food.Fiber *= food.Quantity;
                food.Carbs *= food.Quantity;
                food.ServingSize *= food.Quantity;
                food.Sugar *= food.Quantity;
            }

            return foodToCalc;
        }


        public async Task<FoodServiceModel> Find(int id) 
            => await this.db
            .Food
            .ProjectTo<FoodServiceModel>()
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
