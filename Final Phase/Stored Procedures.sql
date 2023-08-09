create database MvcProject;

use MvcProject;

drop table tBregister;

create table [dbo].[tBregister]
(
 empId int PRIMARY KEY	IDENTITY(1,1) not null,
 empName varchar(100),
 empEmail varchar(50),
 empPassword varchar(50),
 empGender char(1),
 empImage varchar(max)
);

 CREATE PROCEDURE SP_InsertEmployee
    @empName varchar(100),
	@empEmail varchar(50),
	@empPassword varchar(50),
	@empGender char(1),
	@empImage varchar(max)
AS
BEGIN
    INSERT INTO tBregister (empName,empEmail,empPassword,empGender,empImage)
    VALUES (@empName, @empEmail,@empPassword,@empGender,@empImage)
END

 create proc SP_ReadEmployee
 as
 begin
 select * from tBregister;
 end

 exec SP_InsertEmployee "Devananda","deva@gmail.com","deva123",'F',"C:\Users\nanda\Desktop\nanda.jpg";

 exec SP_ReadEmployee
 select * from tBregister;
