use db;


SP_HELP DEPARTMENT;

SP_HELP EMPLOYEES;

SP_HELP SALARIES;

INSERT INTO DEPARTMENT VALUES(101,'SALES');
INSERT INTO DEPARTMENT VALUES(102,'ADMINISTRATION');
INSERT INTO DEPARTMENT VALUES(103,'MANAGEMENT');
INSERT INTO DEPARTMENT VALUES(104,'TECHNOLOGICAL');
INSERT INTO DEPARTMENT VALUES(105,'SUPPORT');

SELECT * FROM DEPARTMENT;

INSERT INTO EMPLOYEES VALUES(111,101,'DEVIKA','DEVADAS','2000-03-05','KERALA','THRISSUR',1234567890,'POUND JN',2);
INSERT INTO EMPLOYEES VALUES(112,102,'UNNIMAYA','P','2000-05-12','KERALA','THRISSUR',7894560123,'THRISSUR',2);
INSERT INTO EMPLOYEES VALUES(113,103,'G','DEVANANDA','2000-02-27','KERALA','CALICUT',1472583693,'PARAMBATH',5);
INSERT INTO EMPLOYEES VALUES(114,102,'SALIH','P','1999-08-25','KERALA','MALAPPURAM',3366568974,'PERINTHALMANNA',5);
INSERT INTO EMPLOYEES VALUES(115,103,'SHIBI','K P','1978-05-05','KERALA','CALICUT',1122445577,'ATHOLI',3);
INSERT INTO EMPLOYEES VALUES(116,104,'SYAMA','GHANA','2007-07-16','KERALA','CALICUT',1122334455,'KAKKODI',2);
INSERT INTO EMPLOYEES VALUES(117,105,'AZAD','M S','1999-07-25','KERALA','KOTTAYAM',7845129623,'KOTTAYAM',4);
INSERT INTO EMPLOYEES VALUES(118,104,'ANAKHA','PAVITHRAN','1999-10-18','KOTTAYAM','PIRAVOM',7894560112,'PIRAVOM',4);
INSERT INTO EMPLOYEES VALUES(119,101,'LAKSHMI','C','2000-04-28','KERALA','MALAPPURAM',1145785585,'THRISSUR',3);
INSERT INTO EMPLOYEES VALUES(120,105,'NANDA','G','2000-02-27','TAMILNADU','CHENNAI',7785859632,'THRISSUR',4);

SELECT * FROM EMPLOYEES;

INSERT INTO SALARIES VALUES(121,111,10000,'2022-01-07');
INSERT INTO SALARIES VALUES(122,112,15000,'2022-02-17');
INSERT INTO SALARIES VALUES(123,113,15000,'2022-12-02');
INSERT INTO SALARIES VALUES(124,114,15000,'2022-11-22');
INSERT INTO SALARIES VALUES(125,115,10000,'2022-10-09');
INSERT INTO SALARIES VALUES(126,116,20000,'2022-11-24');
INSERT INTO SALARIES VALUES(127,117,20000,'2022-02-14');
INSERT INTO SALARIES VALUES(128,118,10000,'2022-10-03');
INSERT INTO SALARIES VALUES(129,119,12000,'2022-02-07');
INSERT INTO SALARIES VALUES(130,120,15000,'2022-11-19');
