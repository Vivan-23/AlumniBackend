create database Alumni;
use alumni;
-- Users table
CREATE TABLE Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Phone VARCHAR(20),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    RoleId INT NOT NULL DEFAULT '1'
);

-- AlumniProfiles table
CREATE TABLE AlumniProfiles (
    AlumniId INT AUTO_INCREMENT PRIMARY KEY,
    CompanyName VARCHAR(150),
    Designation VARCHAR(150),
    LinkedinUrl VARCHAR(255),
    AlumniName VARCHAR(150) NOT NULL,
    Passout_year VARCHAR(10) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Events table
CREATE TABLE Events (
    EventsId INT AUTO_INCREMENT PRIMARY KEY,
    EventName VARCHAR(200) NOT NULL,
    EventDescription TEXT,
    EventTime TIME NOT NULL,
    EventDate DATE NOT NULL,
    EventLocation VARCHAR(200) NOT NULL,
    CreatedBy VARCHAR(100) NOT NULL
);

-- EventRegistrations table
CREATE TABLE EventRegistrations (
    RegistrationId INT AUTO_INCREMENT PRIMARY KEY,
    EventId INT NOT NULL,
    AlumniId INT NOT NULL,
    Status ENUM('yes','no','unsure') NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(EventsId),
    FOREIGN KEY (AlumniId) REFERENCES AlumniProfiles(AlumniId)
);

-- Donations table
CREATE TABLE Donations (
    DonationId INT AUTO_INCREMENT PRIMARY KEY,
    Description TEXT,
    AlumniId INT NOT NULL,
    Amount DOUBLE NOT NULL,
    FOREIGN KEY (AlumniId) REFERENCES AlumniProfiles(AlumniId)
);

-- MentorshipRequests table
CREATE TABLE MentorshipRequests (
    RequestId INT AUTO_INCREMENT PRIMARY KEY,
    AlumniId INT NOT NULL,
    UserId INT NOT NULL,  -- student user
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('Approved','Not_Approved') NOT NULL DEFAULT 'Not_Approved',
    FOREIGN KEY (AlumniId) REFERENCES AlumniProfiles(AlumniId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
-- Roles
CREATE TABLE Roles (
    RoleId INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(200) NOT NULL
);
INSERT INTO Roles (RoleName) VALUES
('Student'),
('Alumni'),
('Admin');
select * from users;