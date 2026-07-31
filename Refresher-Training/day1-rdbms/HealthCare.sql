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