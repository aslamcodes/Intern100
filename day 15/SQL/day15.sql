-- DDL
create database EmployeeDB;
use EmployeeDB;


CREATE TABLE Employee (
    Emp_no int identity(100, 1) primary key,
    Emp_name varchar(200) not null,
    Salary float,
    Dept varchar(100),
    BossNo int,
    CONSTRAINT FK_BOSS_EMP FOREIGN KEY (BossNo) REFERENCES Employee(Emp_no)
);

INSERT INTO Employee (Emp_name, Salary, Dept, BossNo)
VALUES ('Alice', 75000, 'Management', NULL),
       ('Ned', 45000, 'Marketing', 1),
       ('Andrew', 25000, 'Marketing', 2),
       ('Clare', 22000, 'Marketing', 2),
       ('Todd', 38000, 'Accounting', 1),
       ('Nancy', 22000, 'Accounting', 5),
       ('Brier', 43000, 'Purchasing', 1),
       ('Sarah', 56000, 'Purchasing', 7),
       ('Sophile', 35000, 'Personnel', 1),
       ('Sanjay', 15000, 'Navigation', 3),
       ('Rita', 15000, 'Books', 4),
       ('Gigi', 16000, 'Clothes', 4),
       ('Maggie', 11000, 'Clothes', 4),
       ('Paul', 15000, 'Equipment', 3),
       ('James', 15000, 'Equipment', 3),
       ('Pat', 15000, 'Furniture', 3),
       ('Mark', 15000, 'Recreation', 3);


CREATE TABLE Department (
    Deptname varchar(100) primary key,
    floor int,
    phone varchar(30),
    managerId int,
    constraint fk_dept_emp foreign key (managerId) references Employee(Emp_no)
);


INSERT INTO Department (Deptname, floor, phone, managerId)
VALUES ('Management', 5, '34', 1),
       ('Books', 1, '81', 4),
       ('Clothes', 2, '24', 4),
       ('Equipment', 3, '57', 3),
       ('Furniture', 4, '14', 3),
       ('Navigation', 1, '41', 3),
       ('Recreation', 2, '29', 4),
       ('Accounting', 5, '35', 5),
       ('Purchasing', 5, '36', 7),
       ('Personnel', 5, '37', 9),
       ('Marketing', 5, '38', 2);

ALTER TABLE Employee
ADD CONSTRAINT FK_EMP_DEPART FOREIGN KEY (Dept) REFERENCES Department(Deptname);


CREATE TABLE ITEM (
    itemname varchar(100) primary key,
    itemtype varchar(40),
    itemcolor varchar(40)
)

CREATE TABLE SALES (
    Salesno int identity(1, 1) primary key,
    Quantity int,
    itemname varchar(100) not null,
    deptname varchar(100) not null constraint fk_sales_dept FOREIGN key references Department(deptname)
);



--DELETE ALL THE TABLES
alter table Employee drop constraint FK_EMP_DEPART;
alter table Employee drop constraint FK_BOSS_EMP;
drop table Employee;
drop table SALES;
drop table ITEM;
drop table Department;

-- DML
-- Initial Data
INSERT INTO Department (Deptname, floor, phone, managerId)
VALUES ('Management', 5, '34', NULL);

INSERT INTO Employee ()

