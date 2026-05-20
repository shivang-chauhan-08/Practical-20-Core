# ProductManagementAPI

## Project Structure

- Controller → ProductController.cs
- Middleware → ExceptionMiddleware.cs
- Logging → LogHelper.cs
- Repository → Generic Repository & Product Repository
- UnitOfWork → IUnitOfWork.cs, UnitOfWork.cs
- Model/Entities → Product.cs, BaseEntity.cs, AppLog.cs
- Model/Context → ApplicationDBContext.cs
- Logs → log.txt
- Migrations → EF Core Migrations

## Features Implemented

- Global Exception Handling Middleware
- Generic Repository Pattern
- Unit Of Work Pattern
- Async CRUD Operations
- Auditing (CreatedAt, ModifiedAt)
- Database Logging
- File Backup Logging
