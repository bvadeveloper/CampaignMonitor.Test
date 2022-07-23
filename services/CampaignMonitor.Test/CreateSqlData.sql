-- Create database

CREATE DATABASE testdb;

-- Create tables

CREATE TABLE IF NOT EXISTS Salesperson
(
    SalespersonID INT PRIMARY KEY,
    Name          VARCHAR(100) NOT NULL,
    Age           INT          NOT NULL,
    Salary        INT          NOT NULL
);

CREATE TABLE IF NOT EXISTS Customer
(
    CustomerID INT PRIMARY KEY,
    Name       VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Orders
(
    OrderID       INT PRIMARY KEY,
    OrderDate     TIMESTAMP NOT NULL,
    CustomerID    INT       NOT NULL,
    SalespersonID INT       NOT NULL,
    NumberOfUnits INT       NOT NULL,
    CostOfUnit    INT       NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID),
    FOREIGN KEY (SalespersonID) REFERENCES Salesperson (SalespersonID)
);

-- Seed data 

-- Salesperson

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(1,'Alice', 61, 140000);

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(2,'Bob', 34, 44000);

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(6,'Chris', 34, 40000);

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(8,'Derek', 41, 52000);

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(11,'Emmit', 57, 115000);

INSERT INTO Salesperson (SalespersonID, Name, Age, Salary)
VALUES(16,'Fred', 38, 38000);

-- Customer 

INSERT INTO Customer (CustomerID, Name)
VALUES(4,'George');

INSERT INTO Customer (CustomerID, Name)
VALUES(6,'Harry');

INSERT INTO Customer (CustomerID, Name)
VALUES(7,'Ingrid');

INSERT INTO Customer (CustomerID, Name)
VALUES(11,'Jerry');

-- Orders

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(3,'2013-01-17', 4, 2, 4, 400);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(6,'2013-02-07', 4, 1, 1, 600);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(10,'2013-03-04', 7, 6, 2, 300);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(17,'2013-03-15', 6, 1, 5, 300);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(25,'2013-04-19', 11, 11, 7, 300);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(34,'2013-04-22', 11, 11, 100, 26);

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit)
VALUES(57,'2013-07-12', 7, 11, 14, 11);