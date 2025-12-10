# FitnessMember Web API

FitnessMember is a simple RESTful Web API built with ASP.NET Core (.NET 9) and Entity Framework Core using PostgreSQL as the database. The project is used to manage gym members and their enrollment in fitness classes. It demonstrates CRUD operations, the Repository Pattern, dependency injection, and proper entity relationships.

The project uses ASP.NET Core Web API, Entity Framework Core, PostgreSQL with the Npgsql provider, and Swagger for API testing.

The solution contains Controllers, Models, Data, Repositories, and Migrations folders. MembersController handles all API requests. FitnessDbContext manages the database connection and relationships. Member and FitnessClass are the main entities of the system. The Repository layer is used to separate database logic from controllers.

## Requirements
.NET SDK 9+, PostgreSQL, and optionally pgAdmin.


## Install the required packages using:

dotnet add package Microsoft.EntityFrameworkCore  
dotnet add package Microsoft.EntityFrameworkCore.Design  
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL  
dotnet add package Swashbuckle.AspNetCore  

## Configure the PostgreSQL connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=FitnessMemberDB;Username=postgres;Password=yourpassword"
}

## Create the database by running the initial migration:

dotnet ef migrations add InitialCreate  
dotnet ef database update  

## Run the application using:

dotnet run  

## Swagger is available at:

http://localhost:5153/swagger


The API exposes the following endpoints using /api/members:

GET /api/members  
GET /api/members?lastName=value  
POST /api/members  
PUT /api/members/{id}  
DELETE /api/members/{id}  

Sample POST request:

{
  "firstName": "Martin",
  "lastName": "Krsteski",
  "email": "martin@example.com",
  "dateOfBirth": "2002-11-20",
  "membershipStartDate": "2025-12-09T18:45:00Z",
  "fitnessClassId": null
}
