# :hospital: Hospital Visits API

Hospital Visits is a .NET 6.0 based web application that manages hospital visits. It provides functionalities to retrieve hospital data and patient visits.

## Demo API

You can check out the demo API at [this url](https://hospitalvisitsexerciseapi.azurewebsites.net/)

## Architecture

The project follows the principles of Clean Architecture, which is divided into several layers:

- **Domain Layer**: Contains all entities such as `Hospital`, `Doctor`, `Patient`, `PatientVisit`, and `Specialization`.
- **Application Layer**: Contains application logic and is responsible for handling requests and responses using MediatR. It includes queries like `GetHospitalsQuery` and `GetPatientVisitsQuery`.
- **Infrastructure Layer**: Contains classes for accessing the database using Entity Framework. It includes the `HospitalVisitsContext` for database operations and `HospitalRepository` for executing queries on the database.
- **Presentation Layer**: Contains all API controllers. The `HospitalController` is responsible for handling HTTP requests.

The project uses Entity Framework for ORM and MediatR for implementing the Mediator pattern, which helps in reducing the coupling between various components of the application.

CQRS pattern has beed implemented in project

## Installation

1. Clone the repository.
2. Install .NET 6.0 SDK.
3. Run `dotnet restore` to restore the packages.
4. Run `dotnet run` to start the application.

## Pipelines

There are two main pipelines in this project:

1. **Infrastructure Deployment Pipeline**: This pipeline is responsible for deploying the infrastructure required for the application. It deploys a WebApp with an app plan using Azure Bicep templates. The pipeline is defined in the `.github/workflows/pipeline-infrastructure.yml` file. It can be triggered manually

2. **API Deployment Pipeline**: This pipeline is responsible for deploying the API to the WebApp. It is defined in the `.github/workflows/pipeline.yml` file. It triggers after every PR merge
