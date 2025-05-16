# Hotel Room Management Application

This project is a .NET 8.0 Web API application for managing hotel rooms and guests. It follows a clean layered architecture with the Service-Repository pattern and includes comprehensive unit testing.

## Technology Stack

- ASP.NET Core 8.0 Web API
- Entity Framework Core (Code First)
- SQL Server
- AutoMapper
- xUnit for testing
- Service-Repository Pattern

## Project Structure

```
HotelManagement/
├── src/
│   ├── HotelManagement.WebApi/        # API Controllers and entry point
│   ├── HotelManagement.Service/       # Business logic, DTOs, and Services
│   └── HotelManagement.Data/          # EF Core, Entities, and Repositories
└── tests/
    └── HotelManagement.Tests/         # Unit Tests
```

## Entities

### Guest
- Properties:
  - Id (PK, auto-generated)
  - FirstName (required, max 200 chars)
  - LastName (required, max 400 chars)
  - DateOfBirth (required)
  - Address (required, max 600 chars)
  - Nationality (required)
  - CheckInDate (required)
  - CheckOutDate (required)
  - RoomId (FK to Room)

### Room
- Properties:
  - Id (PK, auto-generated)
  - Number (required)
  - Floor (required)
  - Type (required)
  - Guests (navigation property)

## Key Features

1. Complete CRUD operations for both Guest and Room entities
2. Data persistence using Entity Framework Core
3. Service-Repository pattern implementation
4. DTOs for data transfer
5. Dependency Injection and Inversion of Control
6. Comprehensive unit testing

## API Endpoints

### Guests
- GET /api/guests - Get all guests
- GET /api/guests/{id} - Get guest by ID
- POST /api/guests - Create a new guest
- PUT /api/guests/{id} - Update a guest
- DELETE /api/guests/{id} - Delete a guest

### Rooms
- GET /api/rooms - Get all rooms
- GET /api/rooms/{id} - Get room by ID
- POST /api/rooms - Create a new room
- PUT /api/rooms/{id} - Update a room
- DELETE /api/rooms/{id} - Delete a room

## Project Components

### Interfaces
- `IGuestRepository`
- `IRoomRepository`
- `IGuestService`
- `IRoomService`

### DTOs
- `GuestDto`
- `RoomDto`
- `CreateGuestDto`
- `UpdateGuestDto`
- `CreateRoomDto`
- `UpdateRoomDto`

### Services
- `GuestService`
- `RoomService`

### Repositories
- `GuestRepository`
- `RoomRepository`

## Unit Testing

The solution includes comprehensive unit tests for both services:

### GuestService Tests (minimum 3)
- Test guest creation
- Test guest retrieval
- Test guest update

### RoomService Tests (minimum 3)
- Test room creation
- Test room retrieval
- Test room update

## Database Setup

1. Update the connection string in `appsettings.json`
2. Run Entity Framework migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Running the Application

1. Clone the repository
2. Update the connection string
3. Run the migrations
4. Start the application:
```bash
dotnet run --project src/HotelManagement.WebApi
```

## Running Tests

```bash
dotnet test
```

---

**Jovan Tone 5618** 