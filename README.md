# WebAPI

Lightweight ASP.NET Core Web API for basic product CRUD operations using Entity Framework Core and SQL Server.

## Quick links (in this repo)
- Source: [WebAPI/Program.cs](WebAPI/Program.cs)  
- DbContext: [`WebAPI.Data.AppDbContext`](WebAPI/Data/AppDbContext.cs) ([file](WebAPI/Data/AppDbContext.cs))  
- Model: [`WebAPI.Models.ProductModel`](WebAPI/Models/ProductModel.cs) ([file](WebAPI/Models/ProductModel.cs))  
- Controller: [`WebAPI.Controllers.ProductController`](WebAPI/Controllers/ProductController.cs) ([file](WebAPI/Controllers/ProductController.cs))  
- Configuration: [WebAPI/appsettings.json](WebAPI/appsettings.json)  
- Launch profiles: [WebAPI/Properties/launchSettings.json](WebAPI/Properties/launchSettings.json)  
- Project file: [WebAPI/WebAPI.csproj](WebAPI/WebAPI.csproj)  
- Migrations: [WebAPI/Migrations](WebAPI/Migrations)  
- Example SQL: [WebAPI/SQLQuery1.sql](WebAPI/SQLQuery1.sql)  
- HTTP quick tests: [WebAPI/WebAPI.http](WebAPI/WebAPI.http)  
- Solution: [WebAPI.sln](WebAPI.sln)

## Requirements
- .NET 9 SDK
- SQL Server accessible from your machine
- (Optional) EF Core tools: dotnet-ef

## Setup

1. Update the connection string in [WebAPI/appsettings.json](WebAPI/appsettings.json) (key `ConnectionStrings:DefaultConnection`) to point to your SQL Server.
2. From the project folder (where [WebAPI.csproj](WebAPI/WebAPI.csproj) is located) apply migrations:
```sh
dotnet tool install --global dotnet-ef  # if not installed
dotnet ef database update
```

## Run
From the project folder:
```sh
dotnet run
```
Default HTTP URL is shown in [WebAPI/Properties/launchSettings.json](WebAPI/Properties/launchSettings.json) (e.g. http://localhost:5195). Use [WebAPI/WebAPI.http](WebAPI/WebAPI.http) or Swagger (enabled in Development, see [WebAPI/Program.cs](WebAPI/Program.cs)) to test.

## Endpoints (implemented in [`WebAPI.Controllers.ProductController`](WebAPI/Controllers/ProductController.cs))
- GET /api/Product — list all products
- GET /api/Product/{id} — get product by id
- POST /api/Product — create product (Name required, min length 3)
- PUT /api/Product/{id} — update product
- DELETE /api/Product/{id} — delete product

Example POST body (JSON):
```json
{
  "name": "Product A",
  "description": "Description",
  "price": 10.50
}
```

## Notes
- Migrations are already included in [WebAPI/Migrations](WebAPI/Migrations).
- OpenAPI/Swagger and Scalar API reference are mapped in development only (see [WebAPI/Program.cs](WebAPI/Program.cs)).
- Adjust CORS, authentication, and error handling before deploying to production.

Contributions welcome — open issues or PRs on this repo.
