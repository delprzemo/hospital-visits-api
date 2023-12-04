using Application.Models;
using Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{

    public record GetPatientVisitsQuery(string HospitalId, string searchText) : IRequest<List<PatientVisit>>;

    public class GetPatientVisitsQueryHandler : IRequestHandler<GetPatientVisitsQuery, List<PatientVisit>>
    {
        protected readonly ILogger<IRequest> _logger;
        protected readonly IHospitalRepository _hospitalRepository;

        public GetPatientVisitsQueryHandler(ILogger<IRequest> logger, IHospitalRepository hospitalRepository)
        {
            _logger = logger;
            _hospitalRepository = hospitalRepository;
        }

        public async Task<List<PatientVisit>> Handle(GetPatientVisitsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetPatientVisitsQuery.Handle - Retrieving patient visits");
            var patientVisits = await _hospitalRepository.GetPatientVisitsByHospital(request.HospitalId, request.searchText);
            return patientVisits
                .Select(pv => new PatientVisit(
                    pv.Id, 
                    new Hospital(pv.HospitalId, pv.Hospital.Name), 
                    new Patient(pv.PatientId, pv.Patient.FirstName + " " + pv.Patient.LastName),
                    pv.Date, 
                    pv.Specialization.Name,
                    new Doctor(pv.DoctorId, pv.Doctor.FirstName + " " + pv.Doctor.LastName)))
                .ToList();
        }
    }
}
