use db;
--Task 3:SECOND HIGHEST SALARY
SELECT 
	MAX(GROSSS) AS SECOND_HIGHEST_SALARY FROM SALARIES
	WHERE GROSSS<(SELECT MAX(GROSSS) FROM SALARIES ) ;

--Task 4:list of number of employees in each department
SELECT COUNT(EMPLOYEES.FNAME) AS EMPLOYEES, DEPARTMENT.NAME 
	FROM DEPARTMENT INNER JOIN EMPLOYEES ON DEPARTMENT.DEPID=EMPLOYEES.DEPID 
	GROUP BY DEPARTMENT.NAME 
	ORDER BY EMPLOYEES;
--Task 5:USE OF DIFFERENT JOIN FUNCTIONS
SELECT EMPLOYEES.EMPID ,EMPLOYEES.FNAME,EMPLOYEES.LNAME, DEPARTMENT.NAME 
	FROM EMPLOYEES LEFT JOIN DEPARTMENT ON DEPARTMENT.DEPID=EMPLOYEES.DEPID ORDER BY DEPARTMENT.DEPID;


SELECT DEPARTMENT.DEPID, EMPLOYEES.FNAME,EMPLOYEES.LNAME, DEPARTMENT.NAME 
	FROM DEPARTMENT RIGHT JOIN EMPLOYEES ON DEPARTMENT.DEPID=EMPLOYEES.DEPID ORDER BY EMPID ;

SELECT DEPARTMENT.DEPID, EMPLOYEES.FNAME,EMPLOYEES.LNAME, DEPARTMENT.NAME 
	FROM DEPARTMENT FULL OUTER JOIN EMPLOYEES ON DEPARTMENT.DEPID=EMPLOYEES.DEPID ORDER BY EMPID ;

SELECT EMPLOYEES.FNAME,EMPLOYEES.LNAME, SALARIES.GROSSS 
	FROM SALARIES FULL OUTER JOIN EMPLOYEES ON PERSONID=EMPID ORDER BY SALID ;

--Task 7:CRUD Operations performed using stored procedure.

CREATE PROCEDURE sp_InsertEmployees
	@emp_id int,
	@dept_id int,
    @first_name varchar(50),
    @last_name varchar(50),
    @dob date,
	@state varchar(50),
	@city varchar(50),
	@phone bigint,
	@address varchar(50),
	@level int
    AS
    BEGIN
        INSERT INTO EMPLOYEES (EMPID,DEPID,FNAME,LNAME,DOB,STATE,CITY,PHONE,ADRES,LEVEL)
		VALUES(@emp_id,@dept_id,@first_name,@last_name,@dob,@state,@city,@phone,@address,@level)
        
    END

CREATE PROCEDURE sp_GetEmployeesId
    @emp_id int
    AS
    BEGIN
        SELECT * FROM EMPLOYEES
        WHERE EMPID = @emp_id
    END

CREATE PROCEDURE sp_UpdateEmployees
    @dept_id int,
	@emp_id int,
    @first_name varchar(50),
    @last_name varchar(50)
    AS
    BEGIN
        UPDATE EMPLOYEES
        SET FNAME = @first_name,
            LNAME = @last_name,
            DEPID = @dept_id
        WHERE EMPID = @emp_id
    END

CREATE PROCEDURE sp_DeleteEmployees
    @emp_id int
    AS
    BEGIN
        DELETE FROM employees
        WHERE EMPID = @emp_id
    END

--Task 8:To implement a CRUD operations with single stored procedure method

CREATE PROCEDURE sp_CRUD_Departments
	@action varchar(10),
    @department_id int = NULL,
    @dept_name varchar(100) = NULL
    AS
    BEGIN
        IF @action = 'CREATE'
        BEGIN
            INSERT INTO DEPARTMENT(NAME)
            VALUES (@dept_name)
        END
    
        IF @action = 'READ'
        BEGIN
               SELECT * FROM DEPARTMENT
        END
    
        IF @action = 'UPDATE'
        BEGIN
            IF @department_id IS NOT NULL
            BEGIN
                UPDATE DEPARTMENT
                SET NAME = @dept_name
                WHERE DEPID = @department_id
            END
        END
    
        IF @action = 'DELETE'
        BEGIN
            IF @department_id IS NOT NULL
            BEGIN
                DELETE FROM DEPARTMENT
                WHERE DEPID = @department_id
            END
        END
    END

EXEC sp_CRUD_Departments 0,'','READ'
EXEC sp_CRUD_Departments 'PRODUCTION','CREATE'
EXEC sp_CRUD_Departments 0,'','UPDATE'
EXEC usp_Employee_Management 0,'',0,'','DELETE'