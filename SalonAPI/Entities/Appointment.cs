namespace SalonAPI.Entities
{
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }

    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int HairdresserId { get; set; }
        public int TreatmentTypeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? Notes { get; set; }
    }
}