namespace Domain
{
    public class Patient
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public List<PatientVisit> PatientVisits { get; set; }
    }
}