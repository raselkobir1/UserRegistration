CREATE DATABASE UserInformation;
GO

USE UserInformation;
GO

CREATE TABLE dbo.[User] (
    Id bigint PRIMARY KEY IDENTITY(1,1),
    FullName varchar(100) NOT NULL,
    UserName varchar(6) NOT NULL UNIQUE,
    Password varchar(1000) NOT NULL,
    Email varchar(100) NOT NULL,
    Address varchar(1000),
    MobileNumber varchar(15)
);

INSERT INTO dbo.[User] (FullName, UserName, Password, Email, Address, MobileNumber)
VALUES
    ('Md Rasel', 'rasel', '123456', 'rasel@gmail.com', 'Norda, Dhaka', '01773206744');

SELECT * FROM dbo.[User];
