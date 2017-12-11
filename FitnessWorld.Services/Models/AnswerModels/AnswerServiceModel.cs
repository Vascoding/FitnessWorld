using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;
using System;
using AutoMapper;

namespace FitnessWorld.Services.Models.AnswerModels
{
    public class AnswerServiceModel : IMapFrom<Answer>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Published { get; set; }

        public string Author { get; set; }

        public int AuthorPoints { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Answer, AnswerServiceModel>()
            .ForMember(a => a.Author, cfg => cfg
            .MapFrom(a => a.User.Name))
            .ForMember(q => q.AuthorPoints, cfg => cfg
            .MapFrom(q => q.User.Points));
    }
}
