namespace Examino.Domain.Entities
{
    public class Patient : ApplicationUser
    {
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? BloodType { get; set; }
    }
}
