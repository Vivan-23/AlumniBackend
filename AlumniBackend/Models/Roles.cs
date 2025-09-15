using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
