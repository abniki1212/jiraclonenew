# jiraclonenew

This project is an example ASP.NET Core application using Razor Pages and Entity Framework Core.

## Prerequisites

Install the [.NET 8 SDK](https://dotnet.microsoft.com/download) to build and run the project.

## Setup

From the repository root run the following commands after configuring the connection string in *appsettings.json*:

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

