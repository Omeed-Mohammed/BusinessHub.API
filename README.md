# BusinessHub.API

## 🚀 Overview
BusinessHub.API is a modular, production-ready backend system built with ASP.NET Core using Clean Architecture principles.  
It provides a scalable foundation for managing business operations such as Identity and Persons management.

---

## 🏗 Architecture
- Clean Architecture (API / Modules / Infrastructure / Contracts)
- SOLID Principles (SRP, DIP)
- Repository Pattern with Interfaces
- DTO Separation (Entity / Request)
- Mapper Layer (Request ↔ DTO)
- FluentValidation (Validator Layer)
- Global Exception Handling (Middleware)
- Dependency Injection

---

## 🔐 Modules
### Identity
- Users, Roles, Permissions
- RolePermissions, UserRoles
- Secure authentication & password handling

### Persons
- Person Management
- Phones & Notes (Sub-resources)
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
- Clean & scalable architecture  
- Database-driven business rules  
- Production-level design  