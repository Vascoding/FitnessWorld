using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;

namespace FitnessWorld.Services.Models.WorkoutModels
{
    public class WorkoutServiceModel : IMapFrom<Workout>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string VideoId { get; set; }
    }
}
