# Project Name

This README.md file provides instructions for creating and executing migrations in the [Project Name] project.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) - Ensure you have the .NET SDK installed to build and run the project.
- [PostgreSQL](https://www.postgresql.org/download/) - Ensure you have PostgreSQL installed and configured.

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) - Ensure you have the .NET SDK installed to build and run the project.
- [PostgreSQL](https://www.postgresql.org/download/) - Ensure you have PostgreSQL installed and configured.

## Deploying PostgreSQL with Docker Compose

To deploy a new PostgreSQL database, execute the following command in the root directory of your project:

```bash
docker-compose up -d
```

## Getting Started

1. Clone the repository to your local machine:

    ```bash
    git clone https://github.com/your-username/your-repository.git
    ```

2. Navigate to the root directory of the project:

    ```bash
    cd your-project-directory
    ```

3. Ensure that your PostgreSQL database is running and accessible. Update the connection string in the `appsettings.json` file located in the `Service` project with your database credentials:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=your-database-name;Username=your-username;Password=your-password"
      }
    }
    ```

    Replace `"your-database-name"`, `"your-username"`, and `"your-password"` with your actual PostgreSQL database name, username, and password.

4. Open a terminal or command prompt and navigate to the `Infrastructure` project directory:

    ```bash
    cd Infrastructure
    ```

5. Create a new migration using Entity Framework Core's migration command. Replace `"YourMigrationName"` with a meaningful name for your migration:

    ```bash
    dotnet ef migrations add YourMigrationName --startup-project ../Service --context Infrastructure.Context.BaseContext --output-dir Migrations
    ```

    This command creates a new migration file in the `Migrations` directory based on the changes detected in your DbContext.

6. Apply the migration to your database:

    ```bash
    dotnet ef database update --startup-project ../Service
    ```

    This command applies the pending migration to your database, updating its schema to match the changes defined in the migration file.

## Additional Notes

- If you make changes to your database schema or entity classes, repeat steps 5 and 6 to create a new migration and apply it to your database.
- Ensure that your migrations and database schema remain in sync to prevent conflicts and ensure smooth database operations.
