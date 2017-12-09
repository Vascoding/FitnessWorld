using FitnessWorld.Common.Mapping.Contracts;
using FitnessWorld.Data.Models;
using System;
using System.Collections.Generic;

namespace FitnessWorld.Services.Models.QuestionModels
{
    public class QuestionServiceModel : IMapFrom<Question>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public DateTime Published { get; set; }
    }
}
