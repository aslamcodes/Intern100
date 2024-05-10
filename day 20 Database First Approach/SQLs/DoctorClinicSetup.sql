IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'doctorclinic')
BEGIN
    CREATE DATABASE doctorclinic;
END;


USE doctorclinic;


DROP TABLE Appointments;
DROP TABLE Doctors;
DROP TABLE Patients;

CREATE TABLE Patients (
	id int identity(100,1) primary key,
	name varchar(100) not null,
	bloodgroup varchar(40), 
	age int,
	sex varchar(15),
	weight int,
	height int
);

CREATE TABLE Doctors (
	id int identity(100,1) primary key,
	name varchar(100) not null,
	qualification varchar(50),
	speciality  varchar(50),
);

CREATE TABLE Appointments (
	id int identity(100,1) primary key,
	doctorid int constraint fk_doctor foreign key references Doctors(id),
	patientid int constraint fk_patient foreign key references Patients(id)
);

INSERT INTO Patients (name, bloodgroup, age, sex, weight, height) 
VALUES 
('John Doe', 'A+', 30, 'Male', 70, 175),
('Jane Smith', 'O-', 25, 'Female', 60, 165),
('Michael Johnson', 'B+', 45, 'Male', 80, 180),
('Emily Brown', 'AB-', 35, 'Female', 55, 160);

INSERT INTO Doctors (name, qualification, speciality) 
VALUES 
('Dr. Smith', 'MD', 'Cardiology'),
('Dr. Patel', 'MBBS', 'Orthopedics'),
('Dr. Johnson', 'PhD', 'Neurology'),
('Dr. Lee', 'MD', 'Pediatrics');

INSERT INTO Appointments (doctorid, patientid) 
VALUES 
(100, 100), -- Dr. Smith with John Doe
(101, 101), -- Dr. Patel with Jane Smith
(102, 102), -- Dr. Johnson with Michael Johnson
(103, 103); -- Dr. Lee with Emily Brown


SELECT * from Appointments;
SELECT * from Doctors;
SELECT * from Patients;