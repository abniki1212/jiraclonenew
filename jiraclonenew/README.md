# jiraclonenew

This project is an example ASP.NET Core application using Razor Pages and Entity Framework Core.

## Prerequisites

Install the [.NET 8 SDK](https://dotnet.microsoft.com/download) to build and run the project.

## Setup

Before running the project you must configure a valid PostgreSQL connection string.  
Update `appsettings.Development.json` (or set the `ConnectionStrings__DefaultConnection` environment variable) so the `Username` and `Password` match your local database credentials.  
Once the connection string is configured run the following commands from the repository root. The application will automatically apply any pending migrations at startup:

```bash
dotnet restore
dotnet ef database update
dotnet run --project jiraclonenew/jiraclonenew.csproj
```

## Development

Run the application with:

```bash
dotnet run --project jiraclonenew/jiraclonenew.csproj
```

