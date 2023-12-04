namespace Domain
{
    public class  Hospital
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Name { get; init; }
        public List<PatientVisit> PatientVisits { get; set; }
    }
}