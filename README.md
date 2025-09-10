# 🎮 GameStore API

A **RESTful Web API** built with **ASP.NET Core 9.0** and **C#**, following clean architecture principles.  
This project is part of my .NET learning journey, inspired by [Julio Casal’s ASP.NET Core tutorial](https://youtu.be/AhAxLiGC7Pc?si=5sB07q19Ho5aDc3L).

---

## ✨ Features
- CRUD operations for games 🎮
- **Data Transfer Objects (DTOs)** to separate domain models from API contracts
- Input validation and error handling
- **Entity Framework Core** for database access
- Database migrations and seeding
- **Dependency Injection** and service lifetimes
- Fully asynchronous programming model with `async/await`
- Designed for integration with a frontend (Blazor / React)

---

## 🛠 Tech Stack
- [.NET 9.0](https://dotnet.microsoft.com/)  
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/)  
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)  
- SQL Server (local or containerized)

---

## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)  
- SQL Server (local or Docker)  
- Git

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/mazhar-invobyte/GameStore.git
   cd GameStore
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Apply migrations and seed the database:

   ```bash
   dotnet ef database update
   ```

4. Run the project:

   ```bash
   dotnet run --project GameStore.Api
   ```

5. The API will be available at:

   ```
   https://localhost:5001
   http://localhost:5000
   ```

---

## 📌 API Endpoints

| Method | Endpoint      | Description       |
| ------ | ------------- | ----------------- |
| GET    | `/games`      | Get all games     |
| GET    | `/games/{id}` | Get a game by ID  |
| POST   | `/games`      | Create a new game |
| PUT    | `/games/{id}` | Update a game     |
| DELETE | `/games/{id}` | Delete a game     |

---

## 📂 Project Structure

```
GameStore/
 ├── GameStore.Api/        # ASP.NET Core API
 │    ├── Controllers/     # API endpoints
 │    ├── Dtos/            # Data Transfer Objects
 │    ├── Entities/        # Domain models
 │    ├── Data/            # EF Core DbContext
 │    ├── Program.cs       # App entry point
 └── README.md
```

---

## 📖 Learning Goals

* Deepen understanding of **ASP.NET Core** and **C#**
* Learn how to design APIs with clean architecture
* Master **Entity Framework Core** for database operations
* Practice **SOLID principles** and **best practices**

---

## 📜 License

This project is licensed under the MIT License.

```