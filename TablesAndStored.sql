--https://github.com/yorek/azure-sql-db-todo-mvc/blob/main/database/create.sql

--docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d --name DapperTest mcr.microsoft.com/mssql/server:2019-latest

CREATE DATABASE DapperTest
GO

CREATE TABLE dbo.Users (IDUtente int IDENTITY (1,1), [Name] varchar(50), Surname varchar(50), Birthdate date)
GO

CREATE TYPE TVP_User AS TABLE
    (
        IDUtente int IDENTITY (1,1), 
        [Name] varchar(50), 
        Surname varchar(50), 
        Birthdate date
    )

GO

CREATE OR ALTER PROCEDURE proc_Users_Insert
    @Name varchar(50),
    @Surname varchar(50),
    @Birthdate date
AS
BEGIN

    SET NOCOUNT ON

    INSERT INTO dbo.Users ([Name], Surname, Birthdate)
    OUTPUT Inserted.IDUtente, Inserted.Name, Inserted.Surname, Inserted.Birthdate
    VALUES (@Name, @Surname, @Birthdate)


END