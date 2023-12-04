namespace Application.Models
{
    public record PatientVisit(string Id, Hospital hospital, Patient patient, DateTime DateOfVisit, string Specialization, Doctor doctor);
}
