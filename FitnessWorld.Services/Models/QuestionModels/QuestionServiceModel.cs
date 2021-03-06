﻿using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;
using System;
using AutoMapper;

namespace FitnessWorld.Services.Models.QuestionModels
{
    public class QuestionServiceModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Published { get; set; }

        public string AuthorEmail { get; set; }

        public string Author { get; set; }

        public int AuthorPoints { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Question, QuestionServiceModel>()
            .ForMember(q => q.Author, cfg => cfg
            .MapFrom(q => q.User.Name))
            .ForMember(q => q.AuthorPoints, cfg => cfg
            .MapFrom(q => q.User.Points))
            .ForMember(q => q.AuthorEmail, cfg => cfg
            .MapFrom(q => q.User.Email));
    }
}
