# jiraclonenew

This project is an example ASP.NET Core application using Razor Pages and Entity Framework Core.

## Setup

To ensure the database schema is up to date, apply the EF Core migrations after configuring the connection string in *appsettings.json*:

```bash
# with the .NET SDK installed
dotnet ef database update
```

## Development

Run the application with:

```bash
dotnet run --project jiraclonenew/jiraclonenew.csproj
```

