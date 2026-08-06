📅 Day 1 – DBMS Fundamentals & RDBMS Basics
📖 Topics Covered
Introduction to Database Management System (DBMS)
Relational Database Management System (RDBMS)
SQL vs NoSQL
Microsoft SQL Server
T-SQL Basics
DDL Commands
DML Commands
Database Schema Design
Primary Keys
Foreign Keys
One-to-Many Relationships
Constraints for Data Integrity

🛠️ Practical Implementation
Designed and implemented a Health Clinic Database using Microsoft SQL Server.

🗄️ Database Created
HealthClinicDB
📋 Tables Created
Doctor
Patient
Appointment
🔗 Relationships
One Doctor → Many Appointments
One Patient → Many Appointments
🧠 Concepts Implemented
CREATE DATABASE
CREATE TABLE
PRIMARY KEY
FOREIGN KEY
IDENTITY
UNIQUE Constraint
NOT NULL Constraint
🎯 Learning Outcomes
Learned the fundamentals of DBMS and relational databases.
Designed a healthcare database schema following relational database principles.
Created relational tables with appropriate constraints.
Established one-to-many relationships using foreign keys.
Gained hands-on experience with SQL DDL and DML commands.


📅 Day 2 – ER Diagram, Normalization & Indexing
📖 Topics Covered
ER Diagram Design
Entities
Attributes
Relationships
Cardinality
Participation Constraints
Primary Keys
Foreign Keys
Database Normalization
First Normal Form (1NF)
Second Normal Form (2NF)
Third Normal Form (3NF)
SQL Server Indexing
Query Optimization
Execution Plan Analysis
🛠️ Practical Implementation

Enhanced the Health Clinic Database by applying advanced database design and optimization techniques.

✅ Tasks Completed
Created the Room table.
Established the Doctor–Room relationship using a foreign key.
Designed a complete Entity Relationship (ER) Diagram.
Represented entities, attributes, relationships, cardinality, participation, primary keys, and foreign keys.
Added the ER Diagram to the GitHub repository.
Implemented Single Column, Composite, and Covering Indexes.
Created the PatientPhones table for normalization.
Verified database normalization up to 3NF.
Compared query performance before and after indexing using SQL Server Execution Plans.
🗄️ Database Enhancements
New Table
Room
Updated Relationships
One Room → Many Doctors
One Doctor → Many Appointments
One Patient → Many Appointments
📈 Indexes Implemented
Single Column Index
IX_VisitType
Composite Index
IX_Doctor_Date
Covering Index
IX_Covering_Doctor
⚡ Query Optimization

Analyzed query performance using:

Query execution without indexes
Single Column Index
Composite Index
Covering Index

Verified performance improvements through SQL Server Execution Plans (Index Seek).

🧩 Database Normalization

Created the PatientPhones table to support multiple phone numbers for a patient and validated:

✅ First Normal Form (1NF)
✅ Second Normal Form (2NF)
✅ Third Normal Form (3NF)
🎯 Learning Outcomes
Designed a complete ER Diagram using standard database design concepts.
Identified entities, attributes, relationships, cardinality, and participation.
Applied normalization to eliminate redundancy and improve data consistency.
Expanded the database with additional entities and relationships.
Implemented different indexing techniques.
Learned query optimization using execution plans.
Documented SQL scripts and ER diagrams in GitHub.


📅 Day 3 – SQL Joins, Stored Procedures & Triggers
📖 Topics Covered
SQL Joins
INNER JOIN
LEFT JOIN
RIGHT JOIN
FULL OUTER JOIN
Stored Procedures
Parameterized Stored Procedures
SQL Triggers
INSERT Trigger
UPDATE Trigger
DELETE Trigger
Audit Tables
Database Automation
Data Auditing
🛠️ Practical Implementation

Enhanced the Health Clinic Database by implementing advanced SQL programming concepts for querying, automation, and auditing.

✅ Tasks Completed
Performed INNER JOIN to retrieve doctor, patient, and appointment details.
Used LEFT JOIN to display all doctors, including those without appointments.
Executed RIGHT JOIN to retrieve all patients with their appointment information.
Implemented FULL OUTER JOIN to combine doctor and patient appointment records.
Created reusable Stored Procedures for common healthcare operations.
Created audit tables for Doctor, Patient, and Appointment.
Implemented INSERT, UPDATE, and DELETE triggers on the Doctor table.
Implemented INSERT triggers on the Patient and Appointment tables.
Verified automatic audit logging using SQL Server triggers.
🗄️ Database Enhancements
Audit Tables
DoctorAudit
PatientAudit
AppointmentAudit
Triggers
Doctor
TR_Doctor_Insert
TR_Doctor_Update
TR_Doctor_Delete
Patient
TR_Patient_Insert
Appointment
TR_Appointment_Insert
🔗 SQL Joins Practiced

Performed joins using:

Doctor
Patient
Appointment
Room

Implemented:

INNER JOIN
LEFT JOIN
RIGHT JOIN
FULL OUTER JOIN
⚙️ Stored Procedures

Developed reusable stored procedures for:

Retrieving doctor appointments
Viewing patient appointment history
Fetching doctor schedules
Updating appointment status
Managing appointment records
🔄 Database Automation

Implemented SQL Server Triggers to automatically:

Record newly inserted data
Track record updates
Maintain deletion history
Store historical records in audit tables
📊 Audit Logging

Created dedicated Audit Tables to maintain a history of database operations.

Captured information includes:

Record ID
Entity Details
Operation Type (INSERT / UPDATE / DELETE)
Date and Time of Operation


🎯 Learning Outcomes
Gained practical knowledge of SQL Joins.
Created reusable Stored Procedures.
Learned SQL Server Triggers for automation.
Implemented INSERT, UPDATE, and DELETE triggers.
Built Audit Tables for historical record maintenance.
Automated database auditing.
Improved backend SQL programming skills.

💡 Skills Learned
Database Design
Relational Database Modeling
Microsoft SQL Server
T-SQL Programming
Database Schema Design
Primary Keys & Foreign Keys
Data Integrity
ER Diagram Design
Cardinality & Participation
Database Normalization (1NF, 2NF, 3NF)
SQL Constraints
SQL Joins
Single Column Index
Composite Index
Covering Index
Query Optimization
Execution Plan Analysis
Stored Procedures
SQL Triggers
Audit Tables
Database Automation
Backend Database Development

🎯 Project Summary
The Health Clinic Database Management System is a SQL Server-based project developed to strengthen practical knowledge of relational database design and backend database development.

The project demonstrates:
Database Schema Design
ER Modeling
Table Relationships
Primary & Foreign Keys
Data Integrity
Database Normalization
SQL Constraints
SQL Joins
Indexing Techniques
Query Optimization
Stored Procedures
SQL Triggers
Audit Tables
Database Automation

This repository serves as a comprehensive learning project covering fundamental to intermediate SQL Server concepts with practical implementations and organized documentation.
