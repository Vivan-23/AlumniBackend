using System.ComponentModel.DataAnnotations;

namespace AlumniBackend.Models
{
    public class Events
    {
        [Key]
        public int? EventsId { get; set; }
        public string EventName { get; set; }
        public string? EventDescription { get; set; }
        public DateTime EventTime { get; set; }
        public DateOnly EventDate { get; set; }
        public string EventLocation { get; set; }
        public string createdby { get; set; }
        public ICollection<EventRegistration> EventRegistration { get; set; }

    }
}
