using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class MentorshipRequest
    {
        public enum status
        {
            Approved,
            Not_Approved
        }
        [Key]
        public int? RequestId { get; set; }
        public int AlumniId { get; set; }
        public string UserId { get; set; } //role student
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public status Status { get; set; }
    }
}
