
--Task 1,2 and 6: create table,insert data into the fields and combining tables together using primary key and foreign keys.
create database db;
use db;

create table DEPARTMENT
(
	DEPID INT PRIMARY KEY,
	NAME VARCHAR(50)
);

CREATE  TABLE EMPLOYEES
(
	EMPID INT PRIMARY KEY,
	DEPID INT FOREIGN KEY REFERENCES DEPARTMENT (DEPID),
	FNAME VARCHAR(50),
	LNAME VARCHAR(50), 
	DOB   DATETIME,
	STATE VARCHAR(50),
	CITY  VARCHAR(50),
	PHONE BIGINT,
	ADRES VARCHAR(50),
	LEVEL INT
);

DROP TABLE DEPARTMENT;
DROP TABLE EMPLOYEES;
DROP TABLE SALARIES;

CREATE TABLE SALARIES
(
	SALID		INT PRIMARY KEY,
	PERSONID	INT FOREIGN KEY REFERENCES EMPLOYEES (EMPID),
	GROSSS		MONEY,
	SALDATE		DATETIME
);