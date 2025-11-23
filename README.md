# DataBaseMapping

DataBaseMapping is a simple .NET 8 console sample demonstrating how to connect to a PostgreSQL database and perform basic CRUD operations using three approaches:

- Raw `Npgsql` (Ado.NET-style usage of `NpgsqlConnection`/`NpgsqlCommand`)
- `Dapper` micro-ORM mapping
- `Entity Framework Core` (EF Core) DbContext usage

The project includes example implementations for creating, reading, updating, and deleting records from an example `account` table.

## Features

- Connect to PostgreSQL using `Npgsql`.
- Perform CRUD using raw SQL commands.
- Map query results to C# objects using `Dapper`.
- Use EF Core `DbContext` and `DbSet<T>` to query and modify entities.

## Prerequisites

- .NET 8 SDK
- PostgreSQL server
- NuGet packages used in this project:
  - `Npgsql`
  - `Dapper`
  - `Microsoft.EntityFrameworkCore`
  - `Npgsql.EntityFrameworkCore.PostgreSQL`

Configure your PostgreSQL connection string in the source files before running. Example connection string used in the project:

```
Host=localhost;Port=5432;Username=postgres;Password=epam;Database=my_db
```

Replace credentials and database name as appropriate for your environment.

## Project structure

- `DataBaseMapping.csproj` - project file targeting .NET 8
- `NpgSql/Npgsql.cs` - ADO.NET-style examples using `NpgsqlConnection` and `NpgsqlCommand`. Contains CRUD helper methods (`CreateAccount`, `ReadAccounts`, `UpdateAccount`, `DeleteAccount`).
- `Dapper/DapperMapping.cs` - Dapper example mapping query results to an `Account` POCO and demonstrating CRUD operations using `db.Execute` / `db.Query<T>`.
- `EntityFrameworkCore/EFCore.cs` - EF Core example with `AppDbContext` and `Account` entity showing how to use `DbContext` and `DbSet<Account>` for CRUD operations.
- `README.md` - this file

## Database schema (example)

This project expects an `account` table with at least the following columns:

- `id` (integer, primary key)
- `name` (text / varchar)
- `balance` (numeric / integer)

Example SQL to create a minimal table:

```sql
CREATE TABLE account (
  id SERIAL PRIMARY KEY,
  name TEXT NOT NULL,
  balance INTEGER NOT NULL
);
```

## Running the samples

1. Ensure PostgreSQL is running and reachable.
2. Update the connection string in source files if needed.
3. From the project root run:

```
dotnet run --project DataBaseMapping.csproj
```

Each example file contains a `Main` entry point; adjust or run the specific file you want to test (you can comment out or rename mains to avoid conflicts when running).

## Notes

- The samples are minimal and intended for learning/demonstration. Do not use these examples as-is in production without adding proper error handling, logging, input validation, and secrets management.
- Use parameterized queries (shown in the examples) to avoid SQL injection.

## Author

- Sumanta Swain (GitHub: `SumantaSwainEpam`)

## License

This repository does not include an explicit license. Add a license file if you intend to publish or share this code.