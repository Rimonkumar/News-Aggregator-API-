# 📰 NewsAggregatorAPI

A scalable and modular Web API built with **ASP.NET Core** using **N-Tier Architecture**.
This project demonstrates clean separation of concerns and is designed for aggregating and managing news content from various sources.
Ideal for learning enterprise-level backend architecture, clean code principles, and web API development.

---

## ✅ Features

- N-Tier Architecture (Presentation, BLL, DAL, Model)
- RESTful API for CRUD operations on news articles
- Entity Framework Core integration
- Repository & Service pattern implementation
- Supports SQL Server or SQLite (configurable)
- Clean, maintainable, and extensible codebase

---

## 📁 Project Structure
NewsAggregatorAPI/

├── NewsAggregator.API # Presentation Layer (Controllers, Startup)

├── NewsAggregator.BLL # Business Logic Layer (Services, Interfaces)

├── NewsAggregator.DAL # Data Access Layer (Repositories, DbContext)

├── NewsAggregator.Models # Entity & DTO classes

├── NewsAggregator.sln # Solution File
