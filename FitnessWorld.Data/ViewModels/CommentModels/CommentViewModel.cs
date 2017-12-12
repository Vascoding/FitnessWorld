using FitnessWorld.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace FitnessWorld.Data.ViewModels.CommentModels
{
    using static DataConstants;

    public class CommentViewModel
    {
        [Required]
        [MaxLength(CommentMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int AnswerId { get; set; }
    }
}
