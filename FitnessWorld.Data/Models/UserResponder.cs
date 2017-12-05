namespace FitnessWorld.Data.Models
{
    public class UserResponder
    {
        public string MainUserId { get; set; }

        public User MainUser { get; set; }

        public string ResponderId { get; set; }

        public User Responder { get; set; }
    }
}
