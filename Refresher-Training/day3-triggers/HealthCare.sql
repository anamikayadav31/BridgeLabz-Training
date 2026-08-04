USE HealthCare;

CREATE TABLE Doctor (
    doctor_id INT PRIMARY KEY,
    doctor_name VARCHAR(50) NOT NULL,
    speciality VARCHAR(50),
    contact_no VARCHAR(15)
);

CREATE TABLE Patient (
    patient_id INT PRIMARY KEY IDENTITY(1,1),
    patient_name VARCHAR(50) NOT NULL,
    patient_age INT,
    patient_gender VARCHAR(20),
    patient_contact_no VARCHAR(15),
    patient_address VARCHAR(50)
);

CREATE TABLE Appointment (
    appointment_id INT PRIMARY KEY IDENTITY(1,1),
    doctor_id INT,
    patient_id INT,
    appointment_date DATE,

    FOREIGN KEY (doctor_id) REFERENCES Doctor(doctor_id),
    FOREIGN KEY (patient_id) REFERENCES Patient(patient_id)
);

CREATE TABLE Rooms( room_id int Primary Key,
room_number VARCHAR(20) unique,
room_type varchar(50)
);

CREATE TABLE Doctor_Room(
doctor_id int,
room_id int,
PRIMARY KEY(doctor_id, room_id),
FOREIGN KEY(doctor_id) REFERENCES Doctor(doctor_id),
FOREIGN KEY(room_id) REFERENCES Rooms(room_id)
);


SELECT *
FROM Appointment
WHERE appointment_date='2026-08-05';

-- Single Column Index
CREATE INDEX IN_Appointment_Date ON Appointment(appointment_date);

-- Composite Index
CREATE INDEX IN_Doctor_Date
ON Appointment(doctor_id, appointment_date);


--covering index
CREATE INDEX IX_Covering_Doctor
ON Appointment(doctor_id)
INCLUDE(appointment_date, appointment_id);


--normalization

CREATE TABLE Patient_Phones(
    patient_id INT,
    phone_no VARCHAR(15),
    PRIMARY KEY(patient_id, phone_no),
    FOREIGN KEY(patient_id) REFERENCES Patient(patient_id)
);

--Doctor Audit Table

CREATE TABLE Doctor_audit
(
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_id INT,
    doctor_name VARCHAR(50),
    speciality VARCHAR(50),
    contact_no VARCHAR(20),
    action_date DATETIME DEFAULT GETDATE()
);
GO


-- Patient Audit Table
CREATE TABLE patient_audit
(
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_id INT,
    patient_name VARCHAR(50),
    patient_age INT,
    patient_gender VARCHAR(20),
    patient_contact_no VARCHAR(15),
    patient_address VARCHAR(50),
    action_date DATETIME DEFAULT GETDATE()
);
GO


-- Doctor Insert Trigger

CREATE TRIGGER TR_Doctor_Insert
ON Doctor
AFTER INSERT
AS
BEGIN
    INSERT INTO Doctor_audit
    (
        doctor_id,
        doctor_name,
        speciality,
        contact_no
    )
    SELECT
        doctor_id,
        doctor_name,
        speciality,
        contact_no
    FROM inserted;
END;
GO

-- Patient Insert Trigger

CREATE TRIGGER TR_Patient_Insert
ON Patient
AFTER INSERT
AS
BEGIN
    INSERT INTO patient_audit
    (
        patient_id,
        patient_name,
        patient_age,
        patient_gender,
        patient_contact_no,
        patient_address
    )
    SELECT
        patient_id,
        patient_name,
        patient_age,
        patient_gender,
        patient_contact_no,
        patient_address
    FROM inserted;
END;
GO


--Doctor Update Trigger

CREATE TRIGGER TR_Doctor_Update
ON Doctor
AFTER UPDATE
AS
BEGIN
    PRINT 'Doctor record updated.';
END;
GO


-- Patient Update Trigger

CREATE TRIGGER TR_Patient_Update
ON Patient
AFTER UPDATE
AS
BEGIN
    PRINT 'Patient record updated.';
END;
GO


--  Doctor Delete Trigger

CREATE TRIGGER TR_Doctor_Delete
ON Doctor
AFTER DELETE
AS
BEGIN
    PRINT 'Doctor record deleted.';
END;
GO

-- Patient Delete Trigger

CREATE TRIGGER TR_Patient_Delete
ON Patient
AFTER DELETE
AS
BEGIN
    PRINT 'Patient record deleted.';
END;
GO
--insert a record into doctor
INSERT INTO Doctor
VALUES
(101,'Dr. Amit','Cardiology','9876543210');

--insert a record into patient
INSERT INTO Patient
(
patient_name,
patient_age,
patient_gender,
patient_contact_no,
patient_address
)
VALUES
('Rahul',25,'Male','9876543211','Delhi');

--insert records into doctor table
INSERT INTO Doctor
VALUES
(102,'Dr. Ravi Kumar','Neurology','9876543212'),
(103,'Dr. Priya Sharma','Dermatology','9876543213'),
(104,'Dr. Arjun Singh','Orthopedics','9876543214'),
(105,'Dr. Neha Patel','Pediatrics','9876543215'),
(106,'Dr. Mohan Das','General Medicine','9876543220');

--insert records into patient table

INSERT INTO Patient
(
    patient_name,
    patient_age,
    patient_gender,
    patient_contact_no,
    patient_address
)
VALUES
('Rahul Sharma',25,'Male','9876543231','Delhi'),
('Priya Singh',30,'Female','9876543232','Mumbai'),
('Amit Kumar',40,'Male','9876543233','Pune'),
('Neha Verma',28,'Female','9876543234','Jaipur'),
('Rohan Patel',35,'Male','9876543235','Ahmedabad');


--update a record into doctor table
UPDATE Doctor
SET speciality = 'Neurology'
WHERE doctor_id = 102;
----update a record into patient table
UPDATE Patient
SET patient_address = 'Delhi'
WHERE patient_id = 1;

--delete a record into doctor table
DELETE FROM Doctor
WHERE doctor_id = 101;

--delete a record into patient table
DELETE FROM Patient
WHERE patient_id = 1;



--Create Stored procedures for Doctor table
--for searching
CREATE PROCEDURE GetAllDoctors
AS
BEGIN
    SELECT * FROM Doctor;
END;
GO
EXEC GetAllDoctors;


--for update a record
CREATE PROCEDURE UpdateDoctor
(
    @id INT,
    @name VARCHAR(50)
)
AS
BEGIN
    UPDATE Doctor
    SET doctor_name = @name
    WHERE doctor_id = @id;
END;
GO

EXEC UpdateDoctor 103, 'Dr. Amit Kumar';

--for delete a record
CREATE PROCEDURE DeleteDoctor
(
    @id INT
)
AS
BEGIN
    DELETE FROM Doctor
    WHERE doctor_id = @id;
END;
GO

EXEC DeleteDoctor 102;