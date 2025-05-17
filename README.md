# Event Management System

A comprehensive event management solution built using .NET 8.0, consisting of multiple microservices:

- **EventManagmentAPI**: Core API for event management
- **EventManagementMVC**: Web frontend for the application
- **EventManagmentAuth**: Authentication service
- **EventBookingAPI**: API for booking management
- **EventsCore**: Shared core library

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (Local or Express)
- Visual Studio 2022 or VS Code with C# extension

## Database Setup

1. Ensure SQL Server is running
2. Update connection strings in `appsettings.json` files if needed:
   ```json
   "ConnectionStrings": {
     "main": "Data Source=.;Initial Catalog=eventAPI;TrustServerCertificate=True;Integrated Security=True"
   }
   ```

## Project Setup

### 1. Clone the repository
```
git clone <repository-url>
cd EventManagement
```

### 2. Restore dependencies for all projects
```
dotnet restore EventManagmentAPI/EventManagmentAPI.csproj
dotnet restore EventManagementMVC/EventManagementMVC.csproj
dotnet restore EventManagmentAuth/EventManagmentAuth.csproj
dotnet restore EventBookingAPI/EventBookingAPI.csproj
dotnet restore EventsCore/EventsCore.csproj
```

### 3. Apply database migrations
```
cd EventManagmentAPI
dotnet ef database update
cd ..
```

## Running the Application

Run each service in a separate terminal:

### EventManagmentAPI
```
cd EventManagmentAPI
dotnet run
```
API will be available at http://localhost:5000

### EventManagementMVC
```
cd EventManagementMVC
dotnet run
```
Web application will be available at http://localhost:5001

### EventManagmentAuth
```
cd EventManagmentAuth
dotnet run
```
Auth service will be available at http://localhost:7002

### EventBookingAPI
```
cd EventBookingAPI
dotnet run
```
Booking API will be available at http://localhost:5002

## API Documentation

API documentation is available via Swagger UI at `/swagger` endpoint when the API is running.

## Technology Stack

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- ASP.NET MVC
- Swagger/OpenAPI

## Project Structure

- **EventsCore**: Contains shared models and DTOs
- **EventManagmentAPI**: Main API with controllers, repositories, and data access
- **EventManagementMVC**: Web frontend with views and controllers
- **EventManagmentAuth**: Handles authentication and authorization
- **EventBookingAPI**: Manages event booking functionality 