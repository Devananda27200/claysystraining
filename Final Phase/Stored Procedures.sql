create database MvcProject;

use MvcProject;

drop table tBregister;

 create table tBregister(
 empId int PRIMARY KEY	IDENTITY(1000,1),
 empFirstName varchar(50),
 empLastName varchar(50),
 empDateOfBirth date,
 empAge int,
 empGender varchar(25),
 empEmail varchar(50),
 empAddress varchar(100),
 empUsername varchar(50),
 empPassword varchar(50)
 );

 CREATE PROCEDURE SP_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
	@DateOfBirth VARCHAR(50),
	@Age INT,
	@Gender VARCHAR(10),
    @Email VARCHAR(100),
    @Address VARCHAR(200),
	@Username VARCHAR(50),
	@Password VARCHAR(50)
AS
BEGIN
    INSERT INTO tBregister (empFirstName, empLastName,empDateOfBirth,empAge, empGender,empEmail,empAddress,empUsername,empPassword)
    VALUES (@FirstName, @LastName,@DateOfBirth,@Age,@Gender, @Email,@Address,@Username,@Password)
END

 create proc SP_ReadEmployee
 as
 begin
 select * from tBregister;
 end


 select * from tBregister;