using FitnessWorld.Services.Contracts;
using AutoMapper.QueryableExtensions;
using FitnessWorld.Data;

namespace FitnessWorld.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly FitnessWorldDbContext db;

        public AdminService(FitnessWorldDbContext db)
        {
            this.db = db;
        }
    }
}
