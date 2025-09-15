using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class EventRegistration
    {
        public enum status
        {
            yes,
            no,
            unsure

        }
        [Key]
        public int? RegistrationId { get; set; }
        public int EventId { get; set; }
        public int AlumniId { get; set; }
        public status Status { get; set; }

    }
}
