# 💰 Finance Data Processing & Access Control Backend

## 📌 Overview
This project is a backend system built using ASP.NET Core Web API for managing financial records with role-based access control.

It supports:
- User management
- Authentication using JWT
- Financial record CRUD operations
- Dashboard analytics (income, expense, trends)
- Role-based authorization

---

## 🛠 Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / Local DB
- JWT Authentication

---

## 🔐 Authentication

### Login Endpoint
POST /api/auth/login

Request:
{
  "email": "user@example.com",
  "password": "123456"
}

Response:
{
  "token": "your-jwt-token"
}

---

## 👥 User Roles

| Role    | Permissions |
|---------|------------|
| Viewer  | View data only |
| Analyst | View records + dashboard |
| Admin   | Full access |

---

## 👤 User APIs
- GET /api/users
- GET /api/users/{id}
- POST /api/users

---

## 💰 Financial Records APIs
- GET /api/records (filters supported)
- POST /api/records
- PUT /api/records/{id}

---

## 📊 Dashboard APIs
- GET /api/dashboard/summary

Includes:
- Total Income
- Total Expense
- Balance
- Category-wise totals
- Recent transactions
- Monthly trends
- Weekly trends

---

## 🔒 Access Control
- JWT token required
- Use header:
Authorization: Bearer <token>

---

## ✅ Features
- JWT Authentication
- Role-based Authorization
- CRUD operations
- Filtering support
- Dashboard analytics
- Validation & error handling

---

## ⚙️ Setup Instructions

git clone https://github.com/Ankita-008/finance-backend-assignment.git
cd finance-backend-assignment  
dotnet ef database update  
dotnet run  

---

## 📌 Assumptions
- Password stored as plain text (for simplicity)
- Roles stored as string
- Basic JWT authentication

---

## 🚀 Future Improvements
- Password hashing
- Pagination
- Search
- Unit testing

---

## 👨‍💻 Author
Ankita Mohanty
