namespace SalonAPI.Entities
{
    public class Hairdresser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Specialization { get; set; }
        public bool IsActive { get; set; } = true;
    }
}