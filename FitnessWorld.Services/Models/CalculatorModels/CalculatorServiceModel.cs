using AutoMapper;
using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;
using System.Linq;

namespace FitnessWorld.Services.Models.CalculatorModels
{
    public class CalculatorServiceModel : IMapFrom<Food>, IHaveCustomMapping
    {
        public CalculatorServiceModel()
        {
            this.Calc();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int ServingSize { get; set; } = 100;

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fiber { get; set; }

        public int Sugar { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string userId = null;
            mapper.CreateMap<Food, CalculatorServiceModel>()
            .ForMember(c => c.Quantity, cfg => cfg
            .MapFrom(u => u.Users.FirstOrDefault(uf => uf.UserId == userId).Quantity));
        }

        public void Calc()
        {
            this.Calories *= this.Quantity;
            this.Fat *= this.Quantity;
            this.Protein *= this.Quantity;
            this.Carbs *= this.Quantity;
            this.Fiber *= this.Quantity;
            this.Sugar *= this.Quantity;
            this.ServingSize *= this.Quantity;
        }
    }
}
