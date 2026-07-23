# BusinessHub.API

A modular business management backend built with **ASP.NET Core**, following **Clean Architecture** and **SOLID** principles.

BusinessHub is designed as a **Modular Monolith**, providing a scalable foundation for building business applications through independent modules that share a consistent architecture and development standards.

---

## ✨ Features

- Modular Monolith Architecture
- Clean Architecture
- ADO.NET + SQL Server Stored Procedures
- FluentValidation
- Global Exception Handling
- Standardized API Responses
- Thin Controllers
- DTO Separation (Request / Entity)
- Dependency Injection
- Soft Delete (IsActive)

---

## 🏗️ Architecture

```
API
├── Controllers

Modules
├── Services

Infrastructure
├── Repositories

Contracts
├── DTOs
├── Requests

MapperLayer
ValidatorLayer
MiddlewareLayer
```

---

## 📦 Implemented Modules

### Core
- Company
- Company Settings
- Branch
- Client
- Client Type

### Identity
- Login
- Users
- Roles
- Permissions
- User Roles
- Role Permissions

### Persons
- Persons
- Person Phones
- Person Notes

### Projects
- Projects
- Project Tasks
- Project Employees
- Project Status

### Suppliers
- Suppliers

---

## ⚙️ Tech Stack

- ASP.NET Core Web API
- C#
- SQL Server
- ADO.NET
- Stored Procedures
- FluentValidation

---

## 🚧 Project Status

The project is under active development.

### Completed
- Core business modules
- REST API endpoints
- Database layer
- Validation layer
- Global exception handling

### In Progress
- Security hardening
- Authorization policies
- Remaining API integrations
