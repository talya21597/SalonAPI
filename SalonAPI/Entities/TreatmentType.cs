namespace SalonAPI.Entities
{
    public class TreatmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }
    }
}