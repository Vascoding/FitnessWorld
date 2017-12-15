using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessWorld.Data.Models;

namespace FitnessWorld.Data
{
    public class FitnessWorldDbContext : IdentityDbContext<User>
    {
        public FitnessWorldDbContext(DbContextOptions<FitnessWorldDbContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<UserFood> UserFood { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserFood>()
                .HasKey(uf => new { uf.UserId, uf.FoodId });

            builder.Entity<UserFood>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Food)
                .HasForeignKey(uf => uf.UserId);

            builder.Entity<UserFood>()
                .HasOne(uf => uf.Food)
                .WithMany(f => f.Users)
                .HasForeignKey(uf => uf.FoodId);

            builder.Entity<User>()
                .HasMany(u => u.Answers)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.Entity<User>()
                .HasMany(u => u.Questions)
                .WithOne(q => q.User)
                .HasForeignKey(q => q.UserId);

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Category>()
                .HasMany(c => c.Questions)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.CategoryId);

            builder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            builder.Entity<Answer>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Answer)
                .HasForeignKey(c => c.AnswerId);
            
            base.OnModelCreating(builder);
        }
    }
}
