# OnionArch

This project is a sample **ASP.NET Core Web API** application built using  
**Onion Architecture** principles.

The main goal of this project is to demonstrate a clean, maintainable, and
testable backend architecture where dependencies are managed correctly and
business logic is isolated from external concerns.

---

## 🚀 Technologies Used

- ASP.NET Core Web API
- .NET
- Entity Framework Core
- Dependency Injection
- Onion Architecture
- RESTful API

---

## 🧅 What is Onion Architecture?

Onion Architecture is an architectural pattern that enforces
**dependency inversion** by keeping the core business logic at the center
of the application.

Dependencies always flow **from outer layers to inner layers**, never the opposite.

Benefits:
- Better separation of concerns
- High testability
- Low coupling between layers
- Easier long-term maintenance

---

## 📂 Project Structure
OnionArch
│
├── Core
│ └── Domain
│ └── Entities, Value Objects, Domain Rules
│
├── Application
│ └── Interfaces, DTOs, Use Cases
│
├── Infrastructure
│ └── Data Access, EF Core, Repository Implementations
│
└── Presentation
└── WebAPI (Controllers, Middleware, Dependency Injection)

---

##  Navigate to the project directory
	
	cd OnionArch

##  Restore dependencies

	dotnet restore

##  Run the application

	dotnet run

