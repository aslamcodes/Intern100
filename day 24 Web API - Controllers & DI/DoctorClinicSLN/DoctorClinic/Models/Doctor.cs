namespace DoctorClinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specialisation { get; set; }
    }
}
