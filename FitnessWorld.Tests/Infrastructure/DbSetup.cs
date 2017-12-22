using FitnessWorld.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessWorld.Tests.Infrastructure
{
    public class DbSetup
    {
        public FitnessWorldDbContext InitializeTestDb()
        {
            var dbName = Guid.NewGuid().ToString();
            var dbOptionds = new DbContextOptionsBuilder<FitnessWorldDbContext>()
                .UseInMemoryDatabase(dbName).Options;

            return new FitnessWorldDbContext(dbOptionds);
        }
    }
}
