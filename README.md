# Distributed Platform

A simple task management application with REST API and client components.

## Overview

The application consists of three main components:

- **DistributedPlatform.API** - ASP.NET Core Web API for task management
- **DistributedPlatform.Sync** - Data models and business logic
- **DistributedPlatform.UI** - User interface

## Features

- CRUD operations for tasks
- RESTful API
- Automatic in-memory database creation
- Swagger documentation
- CORS support

## Project Structure

```
DistributedPlatform/
├── DistributedPlatform.API/
│   ├── Controllers/
│   │   └── TasksController.cs     # API task controller
│   ├── Data/
│   │   └── AppDbContext.cs        # Entity Framework context
│   ├── Program.cs                 # Application configuration
│   └── appsettings.Development.json
├── DistributedPlatform.Sync/
│   ├── Models/
│   │   └── TaskItem.cs           # Task model
│   └── Class1.cs
└── DistributedPlatform.UI/
    ├── App.xaml
    ├── App.xaml.cs
    └── AssemblyInfo.cs
```

## API Endpoints

- `GET /api/tasks` - Get all tasks
- `GET /api/tasks/{id}` - Get task by ID
- `POST /api/tasks` - Create new task
- `PUT /api/tasks/{id}` - Update task
- `DELETE /api/tasks/{id}` - Delete task

## Data Model

```csharp
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
```

## Running the Application

### Requirements

- .NET 6.0 or later

### Start API

```bash
cd DistributedPlatform.API
dotnet run
```

API will be available at: `http://localhost:5000`

Swagger UI: `http://localhost:5000/swagger`

## Implementation Details

- Uses SQLite in-memory database
- Automatic seed data creation on startup
