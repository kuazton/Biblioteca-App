#  Biblioteca App

[🇺🇸 Read in English](README.md)

## Descripción

Este proyecto es una aplicación web para la gestión de bibliotecas desarrollada en ASP.NET Core MVC con Entity Framework Core. Permite administrar libros, autores, categorías, editoriales, existencias y préstamos, integrando autenticación y gestión de usuarios mediante Identity. Incluye paginación, filtrado dinámico con HTMX y una interfaz moderna con Bootstrap y FontAwesome.

## Características principales
- Gestión completa de libros, autores, categorías, editoriales y existencias.
- Registro de préstamos por usuarios o empleados.
- Autenticación y autorización con Identity (área de gestión de cuenta, MFA, edición de datos personales, etc).
- Paginación y filtrado dinámico en tablas (HTMX + Alpine.js).
- Diseño responsivo y moderno con Bootstrap 5 y FontAwesome.
- Seeders para datos iniciales diferenciados por entorno (desarrollo/producción).

## Requisitos previos
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html)

## Instalación y ejecución

1. **Clona el repositorio:**
   ```bash
   git clone <url-del-repo>
   cd CRUD-Con-vistas
   ```

2. **Restaura los paquetes NuGet:**
   ```bash
   dotnet restore
   ```

3. **Configura la base de datos:**
   - Por defecto usa SQLite. Puedes cambiar la cadena de conexión en `appsettings.json`.
   - Las migraciones y seeders se aplican automáticamente al iniciar la app.

4. **Ejecuta la aplicación:**
   ```bash
   dotnet run
   ```
   O en modo desarrollo con recarga automática:
   ```bash
   dotnet watch run
   ```

5. **Accede a la app:**
   Abre tu navegador en [https://localhost:5001](https://localhost:5001) o la URL indicada en consola.

## Estructura del proyecto
- `Controllers/` — Controladores MVC para cada entidad.
- `Models/` — Modelos de datos y ViewModels.
- `Views/` — Vistas Razor para cada entidad y área de Identity.
- `Services/` — Lógica de negocio y servicios de paginación.
- `data/` — Contexto de base de datos y seeders.
- `wwwroot/` — Archivos estáticos (CSS, JS, librerías frontend).

## Funcionalidades avanzadas
- **Paginación:** Navegación eficiente entre páginas de resultados.
- **Gestión de usuarios:** Registro, login, edición de perfil, MFA, y más.
- **Roles:** Soporte para roles de usuario y empleado.
- **Seeders:** Inicialización de datos para pruebas y producción.

## Personalización
- Puedes modificar los seeders en `data/DatabaseSeeder.cs` para agregar datos personalizados.
- Cambia el diseño en las vistas Razor y los archivos CSS en `wwwroot/css/`.

## Créditos y tecnologías
- ASP.NET Core 9
- Entity Framework Core
- Bootstrap 5
- FontAwesome
- HTMX
- Alpine.js

## Licencia
Este proyecto se distribuye bajo la licencia MIT. Puedes usarlo, modificarlo y distribuirlo libremente.

---

¿Dudas o sugerencias? ¡Crea un issue o un pull request!
