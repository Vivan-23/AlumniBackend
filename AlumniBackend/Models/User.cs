using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class User
    {
        
        public string UserName { get; set; }
        public string Passwordhash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Key]
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        = DateTime.Now;
        public int RoleId { get; set; } = 1;
        public Roles Role { get; set; }
        public ICollection<AlumniProfile> AlumniProfile { get; set; }
    }
}
