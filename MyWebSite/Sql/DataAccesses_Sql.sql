-- the following script will show you how to create/use employee Db

USE Northwind
GO

CREATE PROCEDURE InsertEmployee
	@TitleOfCourtesy    VARCHAR(25),
	@LastName           VARCHAR(20),
	@FirstName          VARCHAR(10),
	@EmployeeID         int OUTPUT
AS
BEGIN
	INSERT INTO Employees 
		(TitleOfCourtesy, LastName, FirstName, HireDate) VALUES (@TitleOfCourtesy, @LastName, @FirstName, GETDATE())
	SET @EmployeeID = @@IDENTITY

END
GO

CREATE PROCEDURE GetEmployeesByCity
	@City    VARCHAR(15)
AS
BEGIN
	SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees WHERE City=@City
END
GO


DECLARE @employeeID INT
EXEC InsertEmployee @TitleOfCourtesy="Mr", @LastName = "Wang", @FirstName = "Joe", @EmployeeID = @employeeID
GO
-- to fetch and check if the data has been pushed to the databse
SELECT TOP 1 * FROM Employees WHERE LastName = 'Wang' and FirstName = 'Joe'
GO

-- drop it 
DELETE FROM Employees WHERE LastName = 'Wang' and FirstName = 'Joe'
GO

IF OBJECT_ID('DeleteEmployee') IS NOT NULL
	DROP PROCEDURE DeleteEmployee
GO

CREATE PROCEDURE DeleteEmployee
	@EmployeeID         int
AS
	DELETE FROM Employees WHERE EmployeeID = @EmployeeID
GO



IF OBJECT_ID('UpdateEmployee') IS NOT NULL
	DROP PROCEDURE UpdateEmployee
GO

CREATE PROCEDURE UpdateEmployee
	@EmployeeID     int,
	@TitleOfCourtesy          VARCHAR(25),
	@LastName       VARCHAR(20),
	@FirstName      VARCHAR(10)
AS
BEGIN
	UPDATE Employees SET TitleOfCourtesy=@TitleOfCourtesy, LastName=@LastName, FirstName=@FirstName WHERE EmployeeID=@EmployeeID
END
GO


IF OBJECT_ID('GetAllEmployees') IS NOT NULL
	DROP PROCEDURE GetAllEmployees
GO

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
	SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees
END
GO

IF OBJECT_ID('GetEmployeePage') IS NOT NULL
	DROP PROCEDURE GetEmployeePage
GO

CREATE PROCEDURE GetEmployeePage
	@Start int,
	@Count int
AS
BEGIN
-- create a temporary table with the columsn we are interested in 
CREATE TABLE #TempEmployees
(
	ID	INT IDENTITY PRIMARY KEY,
	EmployeeID	INT,
	LastName	NVARCHAR(20),
	FirstName	NVARCHAR(10),
	TitleOfCourtesy NVARCHAR(25),
)

-- fill the temp table with all the employees
INSERT INTO #TempEmployees
(
	EmployeeID, LastName, FirstName, TitleOfCourtesy
)
SELECT EmployeeID, LastName, FirstName, TitleOfCourtesy
FROM
	Employees ORDER BY EmployeeID ASC

-- declare two variables and last ID of the range of records 
DECLARE @FromID INT
DECLARE @ToID INT

-- calculate the first and last ID of the range of records we need
SET @FromID = @Start
SET @ToID = @Start + @Count - 1

-- select the page of records
SELECT * FROM #TempEmployees WHERE ID >= @FromID AND ID <= @ToID
END


IF OBJECT_ID('CountEmployees') IS NOT NULL
	DROP PROCEDURE CountEmployees
GO

CREATE PROCEDURE CountEmployees
AS
BEGIN
	SELECT COUNT(EmployeeID) FROM Employees
END
GO

IF OBJECT_ID('GetEmployee') IS NOT NULL
	DROP PROCEDURE GetEmployee
GO
CREATE PROCEDURE GetEmployee
	@EmployeeID	int
AS
	SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees WHERE EmployeeID=@EmployeeID
GO

-- UpdateEmployee
--  note that Last not LastName and First not FirstName
IF OBJECT_ID('UpdateEmployee') IS NOT NULL
	DROP PROCEDURE UpdateEmployee
GO

CREATE PROCEDURE UpdateEmployee
	@EmployeeID         int,
	@Title          VARCHAR(25),
	@Last           VARCHAR(20),
	@First          VARCHAR(10)
AS
BEGIN
	UPDATE Employees SET Title=@Title, LastName=@Last, FirstName=@First WHERE EmployeeID=@EmployeeID
END
GO


-- the following shows you how to use the Transaction

USE Bank
GO

-- initial value insertion 
INSERT INTO Accounts (AccountID, Balance) VALUES ('001', 2000);
GO

INSERT INTO Accounts (AccountID, Balance) VALUES ('002', 5000);
GO

-- fetch the result out

SELECT TOP 1 * FROM Accounts WHERE AccountID = '001'
GO

SELECT TOP 1 * FROM Accounts WHERE AccountID = '002'
GO

-- the following shows you how to use the Transaction

CREATE DATABASE Bank
GO

USE Bank

GO

CREATE TABLE Accounts
(
	AccountID NCHAR(10) PRIMARY KEY,
	Balance MONEY
)

GO

USE Bank
GO

-- initial value insertion 
INSERT INTO Accounts (AccountID, Balance) VALUES ('001', 2000);
GO

INSERT INTO Accounts (AccountID, Balance) VALUES ('002', 5000);
GO

-- fetch the result out

SELECT TOP 1 * FROM Accounts WHERE AccountID = '001'
GO

SELECT TOP 1 * FROM Accounts WHERE AccountID = '002'
GO


-- the following shows you how to use the Transaction


CREATE PROCEDURE TransferAmount
(
	@Amount Money,
	@ID_A   int,
	@ID_B   int
)
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE Accounts SET Balance = Balance  + @Amount WHERE  AccountID = @ID_A
	
	if (@@ERROR > 0)
		GOTO PROBLEM
	
	UPDATE Accounts SET Balance = Balance  - @Amount WHERE  AccountID = @ID_B
	
	if (@@ERROR > 0)
		GOTO PROBLEM 
		
	-- else succeed, commit return
	COMMIT
	RETURN
PROBLEM:
	ROLLBACK
	RAISERROR('Could not update.', 16, 1)
END

GO


-- well a even better is to use the try  catch in sql
IF OBJECT_ID('TransferAmount') IS NOT NULL
	DROP PROCEDURE TransferAmount
GO


CREATE PROCEDURE TransferAmount
(
	@Amount Money,
	@ID_A   int,
	@ID_B   int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		UPDATE Accounts SET Balance = Balance  + @Amount WHERE  AccountID = @ID_A
		UPDATE Accounts SET Balance = Balance  - @Amount WHERE  AccountID = @ID_B
	
		-- else succeed, commit return
		COMMIT
		RETURN
	END TRY
	BEGIN CATCH
		-- an error somewhere has occurred
		if (@@TRANCOUNT > 0) 
			ROLLBACK
		-- notify the client by raising an exception with the error details
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity INT
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END

GO 

SELECT * FROM dbo.Accounts
GO


