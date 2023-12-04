# :hospital: Hospital Visits API

Hospital Visits is a .NET 6.0 based web application that manages hospital visits. It provides functionalities to retrieve hospital data and patient visits.

## Demo API

You can check out the demo API at [api.com/example](http://api.com/example)

## Architecture

The project follows the principles of Clean Architecture, which is divided into several layers:

- **Domain Layer**: Contains all entities such as [Hospital](file:///c%3A/Projects/HospitalVisits/Infrastructure/Database/HospitalVisitsContext.cs#13%2C22-13%2C22), `Doctor[, ](file:///c%3A/Projects/HospitalVisits/HospitalVisits/Extensions/InfrastructureExtensions.cs#10%2C92-10%2C92)Patient`, `PatientVisit`, and [Specialization](file:///c%3A/Projects/HospitalVisits/Infrastructure/Database/HospitalVisitsContext.cs#12%2C22-12%2C22).
- **Application Layer**: Contains application logic and is responsible for handling requests and responses using MediatR. It includes queries like [GetHospitalsQuery](file:///c%3A/Projects/HospitalVisits/HospitalVisits/Controllers/HospitalController.cs#31%2C51-31%2C51) and `GetPatientVisitsQuery`.
- **Infrastructure Layer**: Contains classes for accessing the database using Entity Framework. It includes the `HospitalVisitsContext` for database operations and `HospitalRepository` for executing queries on the database.
- **Presentation Layer**: Contains all API controllers. The `HospitalController` is responsible for handling HTTP requests.

The project uses Entity Framework for ORM and MediatR for implementing the Mediator pattern, which helps in reducing the coupling between various components of the application.

CQRS pattern has beed implemented in project

## Installation

1. Clone the repository.
2. Install .NET 6.0 SDK.
3. Run `dotnet restore` to restore the packages.
4. Run `dotnet run` to start the application.
