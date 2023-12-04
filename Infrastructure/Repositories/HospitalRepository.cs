using Application.Repository;
using Domain;
using Infrastructure.Database;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly HospitalVisitsContext _context;

        public HospitalRepository(HospitalVisitsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientVisit>> GetPatientVisitsByHospital(string hospitalId, string searchText = "")
        {
            return await _context.PatientVisits
                .Include(pv => pv.Hospital)
                .Include(pv => pv.Patient)
                .Include(pv => pv.Doctor)
                .Include(pv => pv.Specialization)
                .Where(pv => pv.HospitalId == hospitalId
                    && (pv.Specialization.Name.ToLower().Contains(searchText)
                        || (pv.Patient.FirstName.ToLower() + " " + pv.Patient.LastName.ToLower()).Contains(searchText)
                        || (pv.Patient.LastName.ToLower() + " " + pv.Patient.FirstName.ToLower()).Contains(searchText)
                        || (pv.Doctor.LastName.ToLower() + " " + pv.Doctor.FirstName.ToLower()).Contains(searchText)
                        || (pv.Doctor.FirstName.ToLower() + " " + pv.Doctor.LastName.ToLower()).Contains(searchText))
                    )
                .ToListAsync();
        }

        public async Task<IEnumerable<Hospital>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }
    }
}
