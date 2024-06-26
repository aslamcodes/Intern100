--create database employeeDB1;
--use employeeDB1;

--use master;
--drop database employeeDB;


CREATE TABLE Employee (
    Emp_no int identity(1, 1) primary key,
    Emp_name varchar(200) not null,
    Salary float,
    Dept varchar(100),
    BossNo int,
   );

   
ALTER TABLE Employee
ADD CONSTRAINT FK_BOSS_EMP FOREIGN KEY (Bossno) REFERENCES Employee(Emp_no);

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
    managerId int not null constraint FK_DEPT_MANAGER foreign key (managerId) references Employee(Emp_no)
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

INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES ('Pocket Knife-Nile', 'E', 'Brown'),
       ('Pocket Knife-Avon', 'E', 'Brown'),
       ('Compass', 'N', NULL),
       ('Geo positioning system', 'N', NULL),
       ('Elephant Polo stick', 'R', 'Bamboo'),
       ('Camel Saddle', 'R', 'Brown'),
       ('Sextant', 'N', NULL),
       ('Map Measure', 'N', NULL),
       ('Boots-snake proof', 'C', 'Green'),
       ('Pith Helmet', 'C', 'Khaki'),
       ('Hat-polar Explorer', 'C', 'White'),
       ('Exploring in 10 Easy Lessons', 'B', NULL),
       ('Hammock', 'F', 'Khaki'),
       ('How to win Foreign Friends', 'B', NULL),
       ('Map case', 'E', 'Brown'),
       ('Safari Chair', 'F', 'Khaki'),
       ('Safari cooking kit', 'F', 'Khaki'),
       ('Stetson', 'C', 'Black'),
       ('Tent - 2 person', 'F', 'Khaki'),
       ('Tent -8 person', 'F', 'Khaki');



CREATE TABLE SALES (
    Salesno int identity(1, 1) primary key,
    Quantity int,
    itemname varchar(100) not null,
    deptname varchar(100) constraint FK_SALES_DEPT foreign key references Department(deptname),
);

INSERT INTO SALES (Quantity, itemname, deptname)
VALUES (2, 'Boots-snake proof', 'Clothes'),
       (1, 'Pith Helmet', 'Clothes'),
       (1, 'Sextant', 'Navigation'),
       (3, 'Hat-polar Explorer', 'Clothes'),
       (5, 'Pith Helmet', 'Equipment'),
       (2, 'Pocket Knife-Nile', 'Clothes'),
       (3, 'Pocket Knife-Nile', 'Recreation'),
       (1, 'Compass', 'Navigation'),
       (2, 'Geo positioning system', 'Navigation'),
       (5, 'Map Measure', 'Navigation'),
       (1, 'Geo positioning system', 'Books'),
       (1, 'Sextant', 'Books'),
       (3, 'Pocket Knife-Nile', 'Books'),
       (1, 'Pocket Knife-Nile', 'Navigation'),
       (1, 'Pocket Knife-Nile', 'Equipment'),
       (1, 'Sextant', 'Clothes'),
       --(1, 'Pocket Knife-Nile', ''),
       (1, 'Exploring in 10 easy lessons', 'Books'),
       --(1, 'How to win foreign friends', ''),
       --(1, 'Compass', ''),
       --(1, 'Pith Helmet', ''),
       (1, 'Elephant Polo stick', 'Recreation'),
       (1, 'Camel Saddle', 'Recreation');
