# 🚀 Harfien – Service Marketplace Backend API

Harfien is a scalable Service Marketplace Backend API built using ASP.NET Core Web API and Clean Architecture principles.
The system connects clients with craftsmen and manages authentication, order lifecycle, wallet transactions, real-time chat, notifications, reviews, and complaints.
It demonstrates secure JWT authentication, role-based authorization, financial transaction handling, SignalR real-time communication, and a well-structured modular backend design suitable for production.


## 🔗 Live Website & Video Demo

- Live Website: _Add your live website URL here (e.g. https://your-live-site.example)_
- Video Demo: _Add your video demo URL here (e.g. https://youtu.be/your-demo-link)_

Note: This repository contains the backend API for the UI shown in the live website and the video demo above.


Harfien connects clients with craftsmen and manages:

- Authentication & Authorization
- Orders Lifecycle
- Wallet & Financial Transactions
- Real-time Chat
- Notifications
- Reviews & Complaints
- Payment Gateway Integration

---

## 📌 Repository

🔗 GitHub:  
https://github.com/salmamohamady68-boop/Harfien_Project

---

## 🏗 Architecture

The project follows **Clean Architecture** with clear separation of concerns:

- **API Layer** (Presentation)
- **Application Layer** (Business Logic)
- **Infrastructure Layer** (Data Access & External Services)
- **Domain Layer** (Core Entities)

### 🔹 Design Principles & Patterns

- SOLID Principles
- Repository Pattern
- Dependency Injection
- Async/Await Best Practices

---

## 🛠 Technologies Used

- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server
- LINQ
- AutoMapper
- ASP.NET Identity
- JWT Authentication
- Role-Based Authorization
- SignalR (Real-time communication)
- Swagger (API Documentation)

---

## 🔐 Authentication & Authorization

- JWT-based secure authentication
- Role-based access control (Client / Craftsman / Admin)
- Secure password hashing using Identity
- Protected endpoints using `[Authorize]`

---

## 📦 Core Modules

### 👤 User Management
- Registration & Login
- Profile management
- City & Area association

### 🛠 Craftsman Module
- Experience 
- Service management
- Availability scheduling
- Admin approval workflow

### 📑 Orders
- Create service request
- Assign craftsman
- Schedule service
- Order lifecycle tracking
- Payment linking

### 💰 Wallet System
- Dedicated wallet per user
- Wallet transaction history
- Order payment handling
- Service fee deduction
- Paginated transaction retrieval

### 💬 Real-Time Chat
- SignalR integration
- Client ↔ Craftsman communication

### 🔔 Notifications
- Order updates
- Payment alerts
- Real-time push notifications

### ⭐ Reviews & Complaints
- Client ratings
- Complaint submission
- Admin resolution workflow

---


## Future Improvements

Redis Caching

Docker Support

CI/CD Pipeline

Performance Optimization

Background Jobs (Hangfire)
---

## ⚙ Installation & Setup
```bash

1️⃣ Clone the Repository

git clone https://github.com/salmamohamady68-boop/Harfien_Project.git
cd Harfien_Project

2️⃣ Configure Database

Update the connection string inside:
appsettings.json
3️⃣ Apply Migrations

Using Package Manager Console:
update-database
Or CLI:
dotnet ef database update

4️⃣ Run the Application
dotnet run
Swagger will be available at:
https://localhost:{port}/swagger

```
