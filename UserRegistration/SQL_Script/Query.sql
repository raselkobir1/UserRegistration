-- Create the UserInformation database
CREATE DATABASE UserInformation;
GO
USE UserInformation;

-- Create the User table
CREATE TABLE [User] (
    Id bigint PRIMARY KEY IDENTITY(1,1),
    FullName varchar(100) NOT NULL,
    UserName varchar(100) NOT NULL UNIQUE,
    Password varchar(1000) NOT NULL,
    Email varchar(100) NOT NULL,
    Address varchar(1000),
    MobileNumber varchar(15)
);
GO
-- Insert data into the User table
INSERT INTO [User] (FullName, UserName, Password, Email, Address, MobileNumber) VALUES
('Md Rasel', 'rasel', '123456', 'rasel@gmail.com', 'Norda, Dhaka', '01773206744');

-- Select all records from the User table
SELECT * FROM [User];
