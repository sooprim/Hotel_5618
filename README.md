# Hotel Web Application

This project is a proof-of-concept web application for managing a hotel's rooms and guests. It is built with .NET 8.0 and follows clean architecture principles. The application includes full support for managing room and guest data, handling check-ins and check-outs, and maintaining proper room occupancy tracking.

## Technology Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- xUnit for testing
- Clean (Layered) Architecture

## Project Structure

- WebApi - Contains API controllers and the application entry point
- Service - Business logic, validation, and DTOs
- Data - Entity Framework Core context and entity models
- Tests - Unit and integration tests

## Features

### 1. Room Management

- Create, read, update, and delete rooms
- Validation:
  - Number is required (unique room identifier)
  - Floor is required (integer value)
  - Type is required (Single, Double, Suite, etc.)
- Handles errors with user-friendly messages

### 2. Guest Management

- Create, read, update, and delete guests
- Validation:
  - FirstName is required (max 200 characters)
  - LastName is required (max 400 characters)
  - DateOfBirth is required
  - Address is required (max 600 characters)
  - Nationality is required
  - CheckInDate and CheckOutDate are required
  - RoomId must reference an existing room
- Includes proper error handling

### 3. Room Assignment

- Assign guests to rooms with validation
- Prevents double-booking of rooms
- Example format:

```json
{
  "firstName": "Jovan",
  "lastName": "Tone",
  "dateOfBirth": "2004-04-28",
  "address": "Street 21, Temecula",
  "nationality": "American",
  "checkInDate": "2025-05-15",
  "checkOutDate": "2025-05-20",
  "roomId": 1
}
```

### 4. Room Availability

- Check room availability for specific dates
- Validates date ranges
- Returns available rooms with their details
- Meaningful error messages for invalid requests

Example response:

```json
[
  {
    "id": 1,
    "number": "101",
    "floor": 1,
    "type": "Single",
    "isAvailable": true
  },
  {
    "id": 2,
    "number": "102",
    "floor": 1,
    "type": "Double",
    "isAvailable": false
  }
]
```

## API Endpoints

### Rooms

- GET /api/Rooms - Get all rooms
- GET /api/Rooms/{id} - Get a room by ID
- POST /api/Rooms - Create a new room
- PUT /api/Rooms/{id} - Update a room
- DELETE /api/Rooms/{id} - Delete a room

### Guests

- GET /api/Guests - Get all guests
- GET /api/Guests/{id} - Get a guest by ID
- POST /api/Guests - Create a new guest
- PUT /api/Guests/{id} - Update a guest
- DELETE /api/Guests/{id} - Delete a guest

## Database Setup

- Ensure SQL Server is running
- Run the `Hotel_DB.sql` script in Microsoft SQL Server Management Studio to create and populate the database
- Update the connection string in appsettings.json if necessary
- The database will be ready with sample rooms and guests

## Running Tests

To run all tests, use:

```bash
dotnet test
```
Alternatively, in Visual Studio 2022, click on Tests -> Run All Tests.

## Error Handling

All endpoints return appropriate error messages for:

- Invalid input data
- Missing or non-existent resources
- Room booking conflicts
- Database constraint violations

## Screenshots

In the following locations are screenshots of the successful endpoint requests and responses:

- [Unit Tests](https://github.com/sooprim/Hotel_5618/blob/main/Screens/UnitTests.PNG)
- [Guests](https://github.com/sooprim/Hotel_5618/tree/main/Screens/Guests)
- [Rooms](https://github.com/sooprim/Hotel_5618/tree/main/Screens/Rooms)

Jovan Tone 5618 
