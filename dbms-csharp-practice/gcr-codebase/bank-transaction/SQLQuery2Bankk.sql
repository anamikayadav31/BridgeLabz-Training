CREATE DATABASE BankDB;
GO
USE BankDB;
GO
CREATE TABLE Accounts(
    AccountId INT PRIMARY KEY,
    HolderName VARCHAR(100),
    Balance DECIMAL(18,2)
);

CREATE TABLE Transactions(
    TransactionId INT PRIMARY KEY IDENTITY(1,1),
    AccountId INT,
    Amount DECIMAL(18,2),
    Type VARCHAR(20),
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY(AccountId) REFERENCES Accounts(AccountId)
);
INSERT INTO Accounts VALUES (1,'Rahul',5000);
DECLARE @AccountId INT = 1;
DECLARE @Amount DECIMAL(18,2) = 500;

BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance - @Amount
WHERE AccountId = @AccountId
AND Balance >= @Amount;

IF @@ROWCOUNT = 0
BEGIN
    ROLLBACK;
    PRINT 'Insufficient Balance';
END
ELSE
BEGIN
    INSERT INTO Transactions(AccountId, Amount, Type)
    VALUES (@AccountId, @Amount, 'Withdrawal');

    COMMIT;
END
SELECT * FROM Accounts;
SELECT * FROM Transactions;
