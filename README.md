🍽 Restaurant Management API

A backend RESTful API built with ASP.NET Core following Clean Architecture principles to manage restaurants, dishes, and customer reviews.

🚀 Tech Stack

ASP.NET Core Web API

Entity Framework Core

SQL Server / MySQL

Clean Architecture (Domain, Application, Infrastructure, API)

Git & GitHub

 Architecture

This project follows Clean Architecture:

Domain          → Core business entities  
Application    → Business logic & DTOs  
Infrastructure → Database & external services  
API (UI)       → Controllers & endpoints  

📌 Features

Restaurant management (create, update, delete, view)

Dish management linked to restaurants

Customer reviews for restaurants and dishes

CRUD APIs with proper layering



🛠 Setup Instructions
1️⃣ Clone repository
git clone https://github.com/IshaManerikar/restaurant-management-api.git

2️⃣ Configure database

Create file:

RestaurantManagement.API/appsettings.Development.json


Use:

appsettings.Development.example.json


as reference.

3️⃣ Update connection string
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING"
}

4️⃣ Run application
dotnet run


API will start on configured port.