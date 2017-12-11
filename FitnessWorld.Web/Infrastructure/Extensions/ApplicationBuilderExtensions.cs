using FitnessWorld.Data;
using FitnessWorld.Data.Models;
using FitnessWorld.Web.Infrastructure.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace FitnessWorld.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<FitnessWorldDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminRole = RoleConstants.Admin;
                        var adminRoleExists = await roleManager.RoleExistsAsync(adminRole);
                       
                        if (!adminRoleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = adminRole
                            });
                        }

                        var adminUser = await userManager.FindByEmailAsync("admin@abv.bg");

                        var user = new User
                        {
                            Name = "Vasko",
                            Email = "admin@abv.bg",
                            UserName = "admin@abv.bg",
                        };

                        if (adminUser == null)
                        {
                            await userManager.CreateAsync(user
                            , "123");

                            await userManager.AddToRoleAsync(user, adminRole);
                        }
                    })
                    .Wait();
            }
            return app;
        }
    }
}
