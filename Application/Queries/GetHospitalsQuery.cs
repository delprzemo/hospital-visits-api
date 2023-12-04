using Application.Models;
using Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{

    public record GetHospitalsQuery() : IRequest<List<Hospital>>;

    public class GetHospitalsQueryHandler : IRequestHandler<GetHospitalsQuery, List<Hospital>>
    {
        protected readonly ILogger<IRequest> _logger;
        protected readonly IHospitalRepository _hospitalRepository;

        public GetHospitalsQueryHandler(ILogger<IRequest> logger, IHospitalRepository hospitalRepository)
        {
            _logger = logger;
            _hospitalRepository = hospitalRepository;
        }

        public async Task<List<Hospital>> Handle(GetHospitalsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetHospitalsQueryHandler.Handle - Retrieving hospitals");
            var hospitals = await _hospitalRepository.GetHospitals();
            return hospitals.Select(h => new Hospital(h.Id, h.Name)).ToList();
        }
    }
}
