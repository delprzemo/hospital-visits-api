using Domain;

namespace Application.Repository
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<PatientVisit>> GetPatientVisitsByHospital(string hospitalId, string searchText = "");
        Task<IEnumerable<Hospital>> GetHospitals();
    }
}
