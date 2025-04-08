# JMS-Backend

Jewelry-Management-System

## Overview

JMS-Backend is an ASP.NET Core Web API project designed to manage a jewelry management system. This project provides various endpoints to handle operations related to jewelry inventory, sales, and customer management.

## Features

- **User Management**: Manage customer information and track customer purchases.
- **Inventory Management**: Manage inventory, including adding, updating, and deleting inventory.
- **Jewelry Management**: Manage jewelry items, including adding, updating, and deleting items.
- **Orders Management**: Handle orders transactions, including creating and viewing order records.
- **Authentication and Authorization**: Secure API endpoints using JWT authentication.
- **Logging**: Integrated logging using NLog.
- **Swagger**: API documentation and testing using Swagger.

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [NLog](https://nlog-project.org/)
- [JWT Authentication](https://jwt.io/)
- [Swagger](https://swagger.io/)

## Getting Started

### Clone the Repository

```sh
git clone https://github.com/HuuTri130401/JMS-Backend.git
cd JMS-Backend
```

### Using Docker
1. Build the Docker image:
```sh
docker-compose build
```

2. Run the Docker containers:
```sh
docker-compose up
```

3. Access the API at:
```sh
 http://localhost:5000/swagger/index.html
```

### Screenshots

User Management
![Create User](./init-db/Images/createuser.png)
![Update User](./init-db/Images/updateuser.png)
![Users List](./init-db/Images/users.png)

Inventory Management
![Create Inventory](./init-db/Images/createinventory.png)
![Inventory List](./init-db/Images/inventory.png)
![Inventory Detail](./init-db/Images/inventorydetail.png)

Jewelry Management
![Create Jewelry](./init-db/Images/createjewelry.png)
![Edit Approve and Update Jewelry](./init-db/Images/editapproveandupdatejewelry.png)
![Delete Jewelry](./init-db/Images/deletejewelry.png)
![Jewelry List](./init-db/Images/jewelry.png)

Orders Management
![Create Order](./init-db/Images/createorder.png)
![Order Detail](./init-db/Images/orderdetail.png)

Login
![Login](./init-db/Images/login.png)