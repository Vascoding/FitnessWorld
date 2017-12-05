namespace FitnessWorld.Data.Models
{
    public class UserResponder
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string ResponderId { get; set; }

        public User Responder { get; set; }
    }
}
