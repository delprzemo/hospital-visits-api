namespace Domain
{
    public class PatientVisit
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public DateTime Date { get; init; }
        public Hospital Hospital { get; init; }
        public string HospitalId { get; set; }
        public Patient Patient { get; init; }
        public string PatientId { get; set; }
        public Doctor Doctor { get; init; }
        public string DoctorId { get; set; }
        public Specialization Specialization { get; init; }
        public string SpecializationId { get; set; }

    }
}