CREATE DATABASE Hotel_DB;
GO

USE Hotel_DB;
GO

CREATE TABLE Rooms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Number NVARCHAR(100) NOT NULL,
    Floor INT NOT NULL,
    Type NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Guests (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(200) NOT NULL,
    LastName NVARCHAR(400) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Address NVARCHAR(600) NOT NULL,
    Nationality NVARCHAR(100) NOT NULL,
    CheckInDate DATETIME NOT NULL,
    CheckOutDate DATETIME NOT NULL,
    RoomId INT NOT NULL,
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO

INSERT INTO Rooms (Number, Floor, Type) VALUES
-- First Floor
('101', 1, 'Single'),
('102', 1, 'Double'),
('103', 1, 'Suite'),
-- Second Floor
('201', 2, 'Single'),
('202', 2, 'Double'),
('203', 2, 'Suite'),
-- Third Floor
('301', 3, 'Penthouse'),
('302', 3, 'Family'),
('303', 3, 'Suite');
GO

INSERT INTO Guests (FirstName, LastName, DateOfBirth, Address, Nationality, CheckInDate, CheckOutDate, RoomId) VALUES
('Jovan', 'Tone', '2004-04-28', 'Street 21, Temecula', 'American', '2025-05-15', '2025-05-20', 1),
('Vangel', 'Tone', '2000-10-16', 'Street 21, Temecula', 'American', '2025-05-15', '2025-05-20', 2),
('Hristo', 'Macovski', '2004-04-10', 'Ulica 17, Skopje', 'Macedonian', '2025-05-20', '2025-05-25', 3),
('Nikola', 'Macovski', '2002-09-02', 'Ulica 17, Skopje', 'Macedonian', '2025-05-20', '2025-05-25', 4),
('Andrej', 'Petrovski', '2001-09-09', 'Ulica 9, Skopje', 'Macedonian', '2025-05-25', '2025-05-30', 5);
GO