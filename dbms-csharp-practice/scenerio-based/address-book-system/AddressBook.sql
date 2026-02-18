CREATE DATABASE AddressBookDB;
GO

USE AddressBookDB;

CREATE TABLE Contacts(
FirstName VARCHAR(50),
LastName VARCHAR(50),
Address VARCHAR(100),
City VARCHAR(50),
State VARCHAR(50),
Zip VARCHAR(20),
Phone VARCHAR(20),
Email VARCHAR(50)
);


select * from Contacts;
