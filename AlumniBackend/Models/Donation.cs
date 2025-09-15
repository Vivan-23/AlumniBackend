using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class Donation
    {
        [Key]
        public int? DonationId { get; set; }
        public string Description { get; set; }
        public int AlumniId { get; set; }
        public double Amount { get; set; }
    }
}
