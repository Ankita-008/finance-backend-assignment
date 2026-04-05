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

## 📸 API Screenshot

Below is the Swagger UI showing available endpoints:
<img width="1840" height="962" alt="Screenshot 2026-04-05 120007" src="https://github.com/user-attachments/assets/c95e1776-ca6d-40d5-8d5a-c5fd27db7aef" />

---

## 📸 API Testing - Postman

Below are some example API requests tested using Postman:
<img width="1905" height="972" alt="Filter" src="https://github.com/user-attachments/assets/b1d5c016-ebd7-4068-8e34-a8a32f99eecc" />
<img width="1915" height="983" alt="GET - Dashboard" src="https://github.com/user-attachments/assets/37585c9d-40b0-429d-9404-4266957ee08d" />
<img width="1907" height="952" alt="login" src="https://github.com/user-attachments/assets/ce32e2b3-7ace-4780-8c3e-e18c645a125c" />


