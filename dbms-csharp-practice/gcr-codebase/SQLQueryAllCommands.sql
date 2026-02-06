--create a database
CREATE DATABASE CollegeDB;
Go
--use database
USE CollegeDB;
GO

--create student table
CREATE TABLE Students (
    student_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50),
    email VARCHAR(100) UNIQUE,
    age INT CHECK (age >= 17),
    course VARCHAR(50)
);

--insert values
INSERT INTO Students (first_name, last_name, email, age, course)
VALUES
('Aarav','Sharma','aarav.sharma@gmail.com',20,'Computer Science'),
('Ananya','Verma','ananya.verma@gmail.com',21,'Information Technology'),
('Rohan','Mehta','rohan.mehta@gmail.com',22,'Mechanical');


--select
SELECT * FROM Students;

--where
SELECT * FROM Students WHERE age > 20;

--update
UPDATE Students SET age = 23 WHERE first_name='Rohan';

--delete
DELETE FROM Students WHERE first_name='Ananya';

--SELECT specific columns
SELECT first_name, age FROM Students;

--DISTINCT (remove duplicates)
SELECT DISTINCT course FROM Students;

--WHERE conditions
SELECT * FROM Students
WHERE age > 20 AND course='Mechanical';

--LIKE (pattern search)
SELECT * FROM Students
WHERE first_name LIKE 'A%';

--BETWEEN
SELECT * FROM Students
WHERE age BETWEEN 18 AND 22;


--in
SELECT * FROM Students
WHERE course IN ('IT','Mechanical');


--ORDER BY
SELECT * FROM Students
ORDER BY age DESC;

--GROUP BY
SELECT course, COUNT(*) AS TotalStudents
FROM Students
GROUP BY course;

--MAX / MIN
SELECT MAX(age), MIN(age) FROM Students;

--AVG
SELECT AVG(age) FROM Students;


-- add constrainsts
ALTER TABLE Students
ADD CONSTRAINT chk_age CHECK(age>=17);

--drop constraints
ALTER TABLE Students
DROP CONSTRAINT chk_age;

--create index
CREATE INDEX idx_email
ON Students(email);

--drop index
DROP INDEX idx_email ON Students;

--create view
CREATE VIEW StudentView AS
SELECT first_name, age, course
FROM Students;
--use view
SELECT * FROM StudentView;

--drop view
DROP VIEW StudentView;

-- create stored procedures
CREATE PROCEDURE GetStudents
AS
SELECT * FROM Students;

--execute
EXEC GetStudents;

--NORMALIZATION
--create course table
CREATE TABLE Courses (
    course_id INT IDENTITY(1,1) PRIMARY KEY,
    course_name VARCHAR(50) UNIQUE
);

--insert
INSERT INTO Courses (course_name)
SELECT DISTINCT course FROM Students;

--add course-id to students
ALTER TABLE Students
ADD course_id INT;


--map course_id to students
UPDATE s
SET course_id = c.course_id
FROM Students s
JOIN Courses c
ON s.course = c.course_name;

--add foreign key
ALTER TABLE Students
ADD CONSTRAINT FK_Course
FOREIGN KEY (course_id)
REFERENCES Courses(course_id);

--remove old column
ALTER TABLE Students
DROP COLUMN course;

--view after normalization
SELECT 
    s.first_name,
    s.email,
    s.age,
    c.course_name
FROM Students s
JOIN Courses c
ON s.course_id = c.course_id;




