# BusinessHub.API

## 🚀 Overview
BusinessHub.API is a modular, production-ready backend system built with ASP.NET Core using Clean Architecture principles.  
It provides a scalable foundation for managing business operations including **Core, Identity, and Persons modules**.

---

## 🏗 Architecture
- Clean Architecture (API / Modules / Infrastructure / Contracts)
- SOLID Principles (SRP, DIP)
- ADO.NET + Stored Procedures (No ORM)
- DTO Separation (Request / Entity)
- Mapper Layer (Request → DTO)
- FluentValidation (Validator Layer)
- Global Exception Handling (Middleware)
- Dependency Injection
- Thin Controllers + ApiResponse<T>

---

## 🔐 Modules

### Core ✅
- Company Management (CRUD + Activation)
- Company Settings
- Branch Management per Company
- Client Management per Company

### Identity
- Users, Roles, Permissions
- RolePermissions, UserRoles
- Secure authentication (BCrypt)

### Persons
- Person Management
- Phones & Notes
- Search & filtering

---

## ⚙️ Tech Stack
- ASP.NET Core Web API
- ADO.NET
- SQL Server (Stored Procedures)
- FluentValidation

---

## ▶️ Run
1. Clone repo  
2. Configure `appsettings.json` (ConnectionString)  
3. Run project  
4. Open Swagger  

---

## 📌 Highlights
- Modular Monolith Architecture  
- Database-driven business rules  
- Soft Delete (IsActive)  
- Production-ready structure  

---

## 📦 Status
- Core Module ✔ Completed  
- Identity Module ✔ Completed  
- Persons Module ✔ Completed  
- Ready for next modules (DebtFlow, HR, Projects)