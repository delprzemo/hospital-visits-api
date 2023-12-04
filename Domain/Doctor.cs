namespace Domain
{
    // TODO: Inherit from Entity
    public class Doctor
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public List<PatientVisit> PatientVisits { get; set; }
    }
}