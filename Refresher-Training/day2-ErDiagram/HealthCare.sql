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


CREATE TABLE Patient_Phones(
    patient_id INT,
    phone_no VARCHAR(15),
    PRIMARY KEY(patient_id, phone_no),
    FOREIGN KEY(patient_id) REFERENCES Patient(patient_id)
);