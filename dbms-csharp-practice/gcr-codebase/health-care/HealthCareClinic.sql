--create database
CREATE DATABASE HealthClinicDB;
GO

--use database
USE HealthClinicDB;
GO


--table:Specialists
CREATE TABLE specialists (
    specialist_id INT IDENTITY(1,1) PRIMARY KEY,
    specialist_name VARCHAR(100) UNIQUE NOT NULL
);

--Table:Doctor
CREATE TABLE doctor (
    doctor_id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_name VARCHAR(100) NOT NULL,
    contact VARCHAR(15),
    consultation_fee DECIMAL(10,2),
    specialist_id INT,
    is_active BIT DEFAULT 1,
    FOREIGN KEY (specialist_id) REFERENCES specialists(specialist_id)
);

--Table:Patient
CREATE TABLE patient (
    patient_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_name VARCHAR(100) NOT NULL,
    dob DATE,
    phone VARCHAR(15) UNIQUE,
    email VARCHAR(100) UNIQUE,
    address VARCHAR(200),
    blood_group VARCHAR(5),
    doctor_id INT,
    FOREIGN KEY (doctor_id) REFERENCES doctor(doctor_id)
);

--Table:Appintment

CREATE TABLE appointment (
    appointment_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_id INT,
    doctor_id INT,
    appointment_date DATE,
    appointment_time TIME,
    status VARCHAR(20) DEFAULT 'SCHEDULED',
    FOREIGN KEY (patient_id) REFERENCES patient(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctor(doctor_id)
);
--Table:Visit

CREATE TABLE visit (
    visit_id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT,
    diagnosis VARCHAR(200),
    notes VARCHAR(300),
    visit_date DATE DEFAULT GETDATE(),
    FOREIGN KEY (appointment_id) REFERENCES appointment(appointment_id)
);

--Table:prescription

CREATE TABLE prescription (
    prescription_id INT IDENTITY(1,1) PRIMARY KEY,
    visit_id INT,
    medicine_name VARCHAR(100),
    dosage VARCHAR(50),
    duration VARCHAR(50),
    FOREIGN KEY (visit_id) REFERENCES visit(visit_id)
);
--table:bills

CREATE TABLE bills (
    bill_id INT IDENTITY(1,1) PRIMARY KEY,
    visit_id INT,
    total_amount DECIMAL(10,2),
    payment_status VARCHAR(20) DEFAULT 'UNPAID',
    bill_date DATE DEFAULT GETDATE(),
    FOREIGN KEY (visit_id) REFERENCES visit(visit_id)
);

--table:Payment Transactions
CREATE TABLE payment_transactions (
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    bill_id INT,
    payment_date DATE,
    payment_mode VARCHAR(50),
    amount DECIMAL(10,2),
    FOREIGN KEY (bill_id) REFERENCES bills(bill_id)
);
--audit tables

CREATE TABLE doctor_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_id INT,
    action_type VARCHAR(10),
    action_time DATETIME DEFAULT GETDATE()
);

CREATE TABLE patient_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    patient_id INT,
    action_type VARCHAR(10),
    action_time DATETIME DEFAULT GETDATE()
);

CREATE TABLE appointment_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT,
    action_type VARCHAR(10),
    action_time DATETIME DEFAULT GETDATE()
);

CREATE TABLE bills_audit (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    bill_id INT,
    action_type VARCHAR(10),
    action_time DATETIME DEFAULT GETDATE()
);

--triggers

--doctor
CREATE TRIGGER trg_doctor_insert ON doctor
AFTER INSERT AS
INSERT INTO doctor_audit (doctor_id, action_type)
SELECT doctor_id, 'INSERT' FROM inserted;
GO

CREATE TRIGGER trg_doctor_update ON doctor
AFTER UPDATE AS
INSERT INTO doctor_audit (doctor_id, action_type)
SELECT doctor_id, 'UPDATE' FROM inserted;
GO

CREATE TRIGGER trg_doctor_delete ON doctor
AFTER DELETE AS
INSERT INTO doctor_audit (doctor_id, action_type)
SELECT doctor_id, 'DELETE' FROM deleted;
GO


--patient
CREATE TRIGGER trg_patient_insert ON patient
AFTER INSERT AS
INSERT INTO patient_audit (patient_id, action_type)
SELECT patient_id, 'INSERT' FROM inserted;
GO

CREATE TRIGGER trg_patient_update ON patient
AFTER UPDATE AS
INSERT INTO patient_audit (patient_id, action_type)
SELECT patient_id, 'UPDATE' FROM inserted;
GO

CREATE TRIGGER trg_patient_delete ON patient
AFTER DELETE AS
INSERT INTO patient_audit (patient_id, action_type)
SELECT patient_id, 'DELETE' FROM deleted;
GO
--appointment
CREATE TRIGGER trg_appointment_insert ON appointment
AFTER INSERT AS
INSERT INTO appointment_audit (appointment_id, action_type)
SELECT appointment_id, 'INSERT' FROM inserted;
GO


--bills
CREATE TRIGGER trg_bills_insert ON bills
AFTER INSERT AS
INSERT INTO bills_audit (bill_id, action_type)
SELECT bill_id, 'INSERT' FROM inserted;
GO

--stored procedures
--speacialists
CREATE PROCEDURE sp_insert_specialist @name VARCHAR(100)
AS
INSERT INTO specialists VALUES (@name);
GO

CREATE PROCEDURE sp_get_all_specialists
AS
SELECT * FROM specialists;
GO

--doctor
CREATE PROCEDURE sp_insert_doctor
@name VARCHAR(100), @contact VARCHAR(15), @fee DECIMAL(10,2), @specialist INT
AS
INSERT INTO doctor VALUES (@name,@contact,@fee,@specialist,1);
GO

--patient
CREATE PROCEDURE sp_insert_patient
@name VARCHAR(100), @dob DATE, @phone VARCHAR(15),
@email VARCHAR(100), @address VARCHAR(200),
@blood VARCHAR(5), @doctor_id INT
AS
INSERT INTO patient
VALUES (@name,@dob,@phone,@email,@address,@blood,@doctor_id);
GO

--appointment booking
CREATE PROCEDURE sp_book_appointment
@patient_id INT, @doctor_id INT,
@date DATE, @time TIME
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM appointment
        WHERE doctor_id=@doctor_id
        AND appointment_date=@date
        AND appointment_time=@time
        AND status='SCHEDULED'
    )
    BEGIN
        RAISERROR('Doctor not available',16,1);
        RETURN;
    END

    INSERT INTO appointment
    VALUES (@patient_id,@doctor_id,@date,@time,'SCHEDULED');
END;
GO


--visit & billing
CREATE PROCEDURE sp_record_visit
@appointment_id INT, @diagnosis VARCHAR(200), @notes VARCHAR(300)
AS
BEGIN
    INSERT INTO visit VALUES (@appointment_id,@diagnosis,@notes,GETDATE());
    UPDATE appointment SET status='COMPLETED' WHERE appointment_id=@appointment_id;
END;
GO

CREATE PROCEDURE sp_generate_bill
@visit_id INT, @extra DECIMAL(10,2)
AS
BEGIN
    DECLARE @fee DECIMAL(10,2);
    SELECT @fee=d.consultation_fee
    FROM visit v
    JOIN appointment a ON v.appointment_id=a.appointment_id
    JOIN doctor d ON a.doctor_id=d.doctor_id
    WHERE v.visit_id=@visit_id;

    INSERT INTO bills VALUES (@visit_id,@fee+@extra,'UNPAID',GETDATE());
END;
GO



--payment
CREATE PROCEDURE sp_record_payment
@bill_id INT, @mode VARCHAR(50), @amount DECIMAL(10,2)
AS
BEGIN
    UPDATE bills SET payment_status='PAID' WHERE bill_id=@bill_id;

    INSERT INTO payment_transactions
    VALUES (@bill_id,GETDATE(),@mode,@amount);
END;
GO

--sample data
INSERT INTO specialists VALUES
('Cardiologist'),('Dermatologist'),('Orthopedic'),
('Neurologist'),('General Physician');

EXEC sp_insert_doctor 'Dr A','9871111111',800,1;
EXEC sp_insert_doctor 'Dr B','9872222222',600,2;

EXEC sp_insert_patient 'Patient1','1998-01-01','9000000001','p1@mail.com','Pune','A+',1;
EXEC sp_insert_patient 'Patient2','1997-02-02','9000000002','p2@mail.com','Mumbai','B+',2;


