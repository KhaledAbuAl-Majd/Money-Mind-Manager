# Money Mind Manager 💰🧠 (Version 2.0 - Clean Architecture)

**Money Mind Manager** is an advanced, database-centric **Personal Financial Management (PFM)** application. Originally built as a desktop tool, the **V2 overhaul** transitions the project into a modular, highly decoupled system following **Clean Architecture** and **SOLID principles**, making it officially **REST-Ready**.

---

## 🏗️ Architectural Overhaul (V2 Updates)

The application has been re-engineered from a traditional 3-tier structure to a modern **Multi-Project Clean Architecture**. This ensures a strict separation of concerns and inward-pointing dependencies.

### Architecture Layers:
- **MoneyMindManager.Core:** Centralized shared abstractions (`IResult`, `ILogger`), Utilities, and Enums used across all projects.
- **MoneyMindManager.IoC:** A dedicated **Inversion of Control** layer that centralizes **Dependency Injection (DI)** registration and manages service lifetimes.
- **MoneyMindManager.Domain:** The core of the system containing pure **Domain Entities** and **Repository Interfaces** (Abstractions).
- **MoneyMindManager.Application:** Implements the core business logic through dedicated services, handlers, and mappers.
- **MoneyMindManager.Infrastructure:** Handles technical concerns like **ADO.NET** implementations for SQL Server, logging, and cryptography.
- - **MoneyMindManager.APIClient.Abstractions:** Contains the interfaces and contracts for the API Client, ensuring the UI remains independent of the implementation.
- **MoneyMindManager.APIClient:** Provides the concrete implementation of the API abstractions, prepared to handle future RESTful HTTP communication.
- **MoneyMindManager.APIClient (Proxy):** Acts as an abstraction layer between the UI and services, ensuring the system is **REST-Ready** for future API integration.
- **MoneyMindManager.Shared.DTOs:** A standalone project for data contracts to maintain consistency across boundaries.
- **MoneyMindManager.UI:** A "Thin Client" WinForms implementation focused strictly on presentation logic.

### Key Engineering Patterns:
- **SOLID Principles:** Strict adherence to Single Responsibility and Dependency Inversion to ensure scalability.
- **Dependency Injection (DI):** Comprehensive use of constructor-based injection managed by the IoC container.
- **Result Pattern (IResult):** Standardized operation outcomes for clean error handling and status reporting without exception-driven logic.

---

## Features

- **Multi-User Support with Advanced Permissions**
  - Full multi-user architecture with **granular, bitwise permissions**.
  - Each user can have a custom set of permissions controlling access to nearly every feature:
    - Viewing, adding, editing, or deleting transactions
    - Managing categories and subcategories
    - Accessing reports and dashboards
    - Managing debts and loans
    - Exporting data to Excel
    - Locking/unlocking vouchers
  - Permissions are stored efficiently in SQL as **bit fields**, allowing **fast evaluation and flexible combinations**.

- **Database-Centric Logic**
  - Core logic implemented in **T-SQL**, including **Stored Procedures** and **Triggers** to enforce balance calculations, validations, and data integrity at the database level.
  - All business rules are enforced in the database, ensuring consistency regardless of the application layer.

- **Advanced Security**
  - **Password Hashing:** SHA-256 with Salt.
  - **Encrypted Tokens:** "Remember Me" tokens stored locally in **Windows Registry** using **AES encryption**.
  - Role-based and permission-based access control ensures that sensitive operations are only available to authorized users.

- **Comprehensive Financial Management**
  - **Hierarchical Categories:** Parent-child income and expense categories.
  - **Debt & Loan Tracking:** Full tracking with automated balance updates and payment schedules.
  - **Document Management:** Transactions logged via **Vouchers (Income, Expense, Returns)** that can be **locked** to prevent modification.

- **Advanced Search & Reporting**
  - **Full-Text Search** for fast lookups in Arabic and English, in addition to standard `LIKE` searches.
  - **Excel Export:** All grids exportable via **ClosedXML**.
  - **Dynamic Dashboards:** Monthly cash flow, debt reports, top spending categories.

- **System Maintenance**
  - **Error Logging:** Logs to SQL tables and Windows Event Viewer.
  - **Automated Cleanup:** Scheduled procedure runs every 6 months to clear old logs and reorganize Full-Text indexes.

---

## Technology Stack

| Component         | Technology / Library        |
|-----------------|-----------------------------|
| Frontend        | C# .NET (Windows Forms)     |
| UI Library      | Guna.UI2                    |
| Architecture    | Clean Architecture     |
| DI Container    | Microsoft.Extensions.DependencyInjection |
| Database        | SQL Server (T-SQL)          |
| Data Export     | ClosedXML                   |
| Configuration   | JSON & Windows Registry     |

---

## Getting Started

### Prerequisites

- Visual Studio (with .NET Desktop Development workload)
- SQL Server (or Express) with **Full-Text Search** enabled
- .NET Framework 4.8 (or compatible)

### Installation

1. **Database Setup**
   - Execute the provided `MMDBScript.sql` to create all tables, functions, triggers, and stored procedures.

2. **Configure Connection**
   - Open the solution in Visual Studio.
   - Check `App.config` `connectionString` to your SQL Server instance and database.

3. **Build & Run**
   - Build the solution to restore NuGet packages (Guna.UI2, ClosedXML).
   - Run the application.

---

## Notes

- Ensure **Full-Text Search** is installed and enabled on your SQL Server instance.
- **Bitwise permissions** provide a highly flexible, scalable, and efficient user permission system.
- Sensitive data (passwords and "Remember Me" tokens) is securely encrypted.
