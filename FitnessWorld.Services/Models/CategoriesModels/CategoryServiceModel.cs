using AutoMapper;
using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;

namespace FitnessWorld.Services.Models.CategoriesModels
{
    public class CategoryServiceModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Questions { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Category, CategoryServiceModel>()
            .ForMember(c => c.Questions, cfg => cfg
            .MapFrom(c => c.Questions.Count));
    }
}
