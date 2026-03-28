# WrestlingApp - Clean Architecture Practice 🤼‍♂️

This project is a dedicated practice application built to explore and implement **Clean Architecture** principles within the .NET ecosystem. 

## 🎯 Project Goal
The primary objective of this project is to decouple software layers (Domain, Application, Infrastructure, WebAPI), manage dependencies effectively, and master the **Generic Repository Pattern**.

## 🏗️ Architectural Overview
The solution is organized into four distinct layers:
- **Core.Domain:** Contains Entities (`Club`, `Wrestler`) and core business models.
- **Core.Application:** Contains Abstractions (Interfaces) and business logic definitions.
- **Infrastructure:** Handles Data Access (EF Core), Migrations, and the concrete implementation of Repositories.
- **WebAPI:** The entry point of the application, managing Controllers and Dependency Injection (DI) registration.

## 🛠️ Tech Stack
- **Framework:** .NET 8 / ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Patterns:** Clean Architecture, Generic Repository Pattern, Dependency Injection
- **Tools:** Swagger UI, Git/GitHub

## 🚀 Getting Started
1. **Clone the repository:** `git clone https://github.com/your-username/WrestlingApp.git`
2. **Update Connection String:** Modify the `DefaultConnection` in `appsettings.json` to point to your local SQL Server instance.
3. **Apply Migrations:** Run `update-database` in the Package Manager Console to create the database schema.
4. **Run the App:** Press `F5` and use the **Swagger UI** to test the endpoints.

---
*This project was developed by Seyfi as part of a journey to master backend architecture and professional software development standards. 🌱*