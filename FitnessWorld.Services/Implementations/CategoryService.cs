using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Data.ViewModels.CategoryModels;
using FitnessWorld.Services.Contracts;
using FitnessWorld.Services.Models.CategoriesModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWorld.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly FitnessWorldDbContext db;

        public CategoryService(FitnessWorldDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryServiceModel>> AllAsync() 
            => await this.db.Categories.ProjectTo<CategoryServiceModel>().ToListAsync();

        public async Task Create(string name)
        {
            await this.db.Categories.AddAsync(new Category { Name = name });
            await this.db.SaveChangesAsync();
        }

        public async Task<CategoryCrudModel> FindByIdAsync(int id)
            => await this.db
            .Categories
            .Where(c => c.Id == id)
            .ProjectTo<CategoryCrudModel>()
            .FirstOrDefaultAsync();

        public async Task Edit(int id, string name)
        {
            var category = await this.db.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                category.Name = name;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await this.db.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                this.db.Categories.Remove(category);
                await this.db.SaveChangesAsync();
            }
        }
    }
}
