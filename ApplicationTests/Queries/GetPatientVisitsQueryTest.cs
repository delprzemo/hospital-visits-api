using Application.Queries;
using Application.Repository;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace ApplicationTests.Queries
{
    public class GetPatientVisitsQueryTest
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly GetPatientVisitsQueryHandler _handler;
        private readonly CancellationToken _cancellationToken;

        public GetPatientVisitsQueryTest()
        {
            _logger = Substitute.For<ILogger<IRequest>>();
            _hospitalRepository = Substitute.For<IHospitalRepository>();
            _handler = new GetPatientVisitsQueryHandler(_logger, _hospitalRepository);
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_ReturnsListOfPatientVisits()
        {
            // Arrange
            var query = new GetPatientVisitsQuery("hospitalId", "searchText");
            var expectedVisits = BuildPatientVisitList();

            _hospitalRepository.GetPatientVisitsByHospital(query.HospitalId, query.searchText)
                .Returns(expectedVisits);

            // Act
            var result = await _handler.Handle(query, _cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedVisits.Count, result.Count);
        }

        [Fact]
        public async Task Handle_WhenNoData_ReturnsEmptyList()
        {
            // Arrange
            var query = new GetPatientVisitsQuery("hospitalId", "searchText");
            var emptyVisits = new List<PatientVisit>();
            _hospitalRepository.GetPatientVisitsByHospital(query.HospitalId, query.searchText)
                .Returns(emptyVisits);

            // Act
            var result = await _handler.Handle(query, _cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        private List<PatientVisit> BuildPatientVisitList()
        {
            return new List<PatientVisit>() {
                new PatientVisit() {
                    Id = "id1",
                    Date = DateTime.Now,
                    Doctor = new Doctor() {FirstName = "John", LastName="Test" },
                    DoctorId = "doctor1",
                    Hospital = new Hospital() { Name = "Hospital1" },
                    HospitalId = "hospital1",
                    Patient = new Patient() { FirstName = "Patient1", LastName = "Test" },
                    PatientId = "patient1",
                    Specialization = new Specialization() { Name = "Specialization1" }
                },
                new PatientVisit() {
                    Id = "id2",
                    Date = DateTime.Now,
                    Doctor = new Doctor() {FirstName = "John", LastName="Test2" },
                    DoctorId = "doctor1",
                    Hospital = new Hospital() { Name = "Hospital2" },
                    HospitalId = "hospital1",
                    Patient = new Patient() { FirstName = "Patient2", LastName = "Test" },
                    PatientId = "patient1",
                    Specialization = new Specialization() { Name = "Specialization2" }
                },
            };
        }
    }
}
