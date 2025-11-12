# CRUD-Con-vistas

[🇪🇸 Leer en español](README.es.md)

## Description

This project is a web application for library management built with ASP.NET Core MVC and Entity Framework Core. It allows you to manage books, authors, categories, publishers, inventory, and loans, integrating authentication and user management with Identity. It includes pagination, dynamic filtering with HTMX, and a modern interface using Bootstrap and FontAwesome.

## Main Features
- Full management of books, authors, categories, publishers, and inventory.
- Loan registration by users or employees.
- Authentication and authorization with Identity (account management area, MFA, personal data editing, etc).
- Pagination and dynamic table filtering (HTMX + Alpine.js).
- Responsive, modern design with Bootstrap 5 and FontAwesome.
- Seeders for initial data, differentiated by environment (development/production).

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html)

## Installation & Running

1. **Clone the repository:**
   ```bash
   git clone <repo-url>
   cd CRUD-Con-vistas
   ```

2. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

3. **Configure the database:**
   - By default, SQLite is used. You can change the connection string in `appsettings.json`.
   - Migrations and seeders are applied automatically on app startup.

4. **Run the application:**
   ```bash
   dotnet run
   ```
   Or in development mode with hot reload:
   ```bash
   dotnet watch run
   ```

5. **Access the app:**
   Open your browser at [https://localhost:5001](https://localhost:5001) or the URL shown in the console.

## Project Structure
- `Controllers/` — MVC controllers for each entity.
- `Models/` — Data models and ViewModels.
- `Views/` — Razor views for each entity and the Identity area.
- `Services/` — Business logic and pagination services.
- `data/` — Database context and seeders.
- `wwwroot/` — Static files (CSS, JS, frontend libraries).

## Advanced Features
- **Pagination:** Efficient navigation between result pages.
- **User management:** Registration, login, profile editing, MFA, and more.
- **Roles:** Support for user and employee roles.
- **Seeders:** Data initialization for testing and production.

## Customization
- You can modify seeders in `data/DatabaseSeeder.cs` to add custom data.
- Change the design in Razor views and CSS files in `wwwroot/css/`.

## Credits & Technologies
- ASP.NET Core 9
- Entity Framework Core
- Bootstrap 5
- FontAwesome
- HTMX
- Alpine.js

## License
This project is licensed under the MIT License. You are free to use, modify, and distribute it.

---

Questions or suggestions? Open an issue or pull request!
