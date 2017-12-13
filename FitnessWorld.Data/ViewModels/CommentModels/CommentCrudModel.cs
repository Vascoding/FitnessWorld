using AutoMapper;
using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;

namespace FitnessWorld.Data.ViewModels.CommentModels
{
    public class CommentCrudModel : IMapFrom<Comment>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Comment, CommentCrudModel>()
            .ForMember(c => c.QuestionId, cfg => cfg
            .MapFrom(c => c.Answer.QuestionId));
    }
}
