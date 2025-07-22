# Bufferflow.WebApi

Bufferflow.WebApi is an ASP.NET Web API backend for the Bufferflow platform, providing RESTful endpoints for user, question, answer, and voting management. It targets .NET Framework 4.6.1 and uses Entity Framework for data access.

## Features
- User registration and authentication
- Question CRUD (create, read, update, delete)
- Answer CRUD and voting
- Dashboard for listing questions
- Modular controller structure

## Prerequisites
- .NET Framework 4.6.1
- Visual Studio 2017 or later (recommended)
- SQL Server or LocalDB (default connection: `BOFContext`)

## Setup
1. Clone the repository and open `Bufferflow.sln` in Visual Studio.
2. Restore NuGet packages (Visual Studio will prompt or use `nuget restore`).
3. Update the connection string in `Web.config` if needed.
4. Build and run the project (F5 in Visual Studio) or deploy to IIS.

## Dependencies
Key NuGet packages (see `packages.config` for full list):
- EntityFramework 6.2.0
- AutoMapper 7.0.1
- Microsoft.AspNet.WebApi 5.2.4
- Newtonsoft.Json 11.0.1
- Microsoft.ApplicationInsights

## API Endpoints

### User
- `POST /api/User/Add` — Register a new user
- `GET /User/Get/{id}` — Get user by ID
- `POST /api/Users/Login` — Validate user login

### Question (Dashboard)
- `GET /api/dashboard` — List all questions
- `POST /api/Question/Add` — Add a new question
- `PUT /Question/Put/{id}` — Edit a question
- `GET /Question/GetDetails/{id}` — Get question details
- `DELETE /Question/Delete/{id}` — Delete a question

### Answer
- `POST /api/Answer/add/{id}` — Add an answer
- `GET /api/Answer/Get/{id}` — List all answers for a question
- `DELETE /Answer/Delete/{id}` — Delete an answer
- `PUT /Answer/Edit/{id}` — Edit an answer
- `GET /Answer/Vote/{id}` — Get net votes for an answer

### Vote
- `POST /api/Vote/Likevote` — Like an answer
- `POST /api/Vote/Dislikevote` — Dislike an answer

### Miscellaneous
- `GET /api/values` — Example/test endpoint

## Project Structure
- `Controllers/` — API controllers
- `Models/` — Data models
- `App_Start/` — Configuration

## Configuration
- The default database connection is set in `Web.config` under `BOFContext`.
- Update this string to match your SQL Server or LocalDB instance as needed.

## License
Proprietary or specify your license here.
