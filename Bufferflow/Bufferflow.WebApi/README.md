# Bufferflow.WebApi

This is an ASP.NET Web API project targeting .NET Framework 4.6.1. It provides backend services for the Bufferflow solution.

## Prerequisites
- .NET Framework 4.6.1
- Visual Studio 2017 or later (recommended)
- LocalDB or SQL Server (default connection: `BOFContext`)

## Setup
1. Restore NuGet packages (Visual Studio will prompt or use `nuget restore`).
2. Build the solution using Visual Studio or `msbuild`.
3. Update the connection string in `Web.config` if needed.
4. Run the project (F5 in Visual Studio) or deploy to IIS.

## Dependencies
Key NuGet packages (see `packages.config` for full list):
- EntityFramework 6.2.0
- AutoMapper 7.0.1
- Microsoft.AspNet.WebApi 5.2.4
- Newtonsoft.Json 11.0.1

## Project Structure
- `Controllers/` - API controllers
- `Models/` - Data models
- `App_Start/` - Configuration

## License
Proprietary or specify your license here. 