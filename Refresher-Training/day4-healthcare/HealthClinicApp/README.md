# HealthCare Mini System

A one-day console project to showcase **ADO.NET** + **SQL Server** skills:
- 3 tables: `Doctor`, `Patient`, `Appointment` (matches your SSMS schema exactly)
- Full CRUD on all three
- `DoctorService` uses **stored procedures**
- `PatientService` / `AppointmentService` use **plain parameterized SQL**
- `Appointment` demonstrates a **JOIN** across Doctor + Patient via foreign keys

## Setup

1. Open `Database/HealthCare.sql` in SSMS and run the whole script.
   It creates the database, 3 tables, stored procedures, and a bit of sample data.
2. Open `HealthClinicApp.csproj` in Visual Studio (or run `dotnet run` from this folder).
3. If your SQL Server instance name isn't `LocalHost\SQLEXPRESS`, update the
   connection string in `Services/DatabaseConnection.cs`.
4. Run the app — you'll get a console menu for Doctors, Patients, and Appointments.

## Project structure

```
Entities/      Doctor.cs, Patient.cs, Appointment.cs        (plain data models)
Services/      DatabaseConnection.cs, DoctorService.cs,
               PatientService.cs, AppointmentService.cs      (all the ADO.NET code)
Interfaces/    IDoctorService.cs, IPatientService.cs,
               IAppointmentService.cs                        (contracts for each service)
Menu/          MainMenu.cs                                   (console UI)
Database/      HealthCare.sql                                (schema + procs + sample data)
Program.cs                                                    (entry point)
```
