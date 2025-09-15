using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{

    public class AlumniProfile
    {
        [Key]
        public int AlumniId { get; set; }  // Primary Key

        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public string? linkedinurl { get; set; }
        public string AlumniName { get; set; }
        public string Passout_year { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation Properties
        public ICollection<EventRegistration> EventRegistration { get; set; }
        public ICollection<Donation> Donation { get; set; }
        public ICollection<MentorshipRequest> MentorshipRequest { get; set; }
    }

}
