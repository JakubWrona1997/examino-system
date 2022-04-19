namespace Examino.Domain.Entities
{
    public class Doctor : ApplicationUser
    {
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
    }
}
