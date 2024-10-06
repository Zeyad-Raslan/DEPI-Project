-- Create the database
CREATE DATABASE OnlineCoursesDB;
GO

-- Use the newly created database
USE OnlineCoursesDB;
GO

-- Create the 'Instructor' table
CREATE TABLE Instructor (
    ID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    about VARCHAR(MAX) NOT NULL,
    image VARCHAR(MAX) NULL
);
GO

-- Create the 'Course' table
CREATE TABLE Course (
    ID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    type VARCHAR(100) NOT NULL,
    description VARCHAR(MAX) NOT NULL,
    status INT DEFAULT 0,
    image VARCHAR(MAX) NULL
);
GO

-- Create the 'Student' table
CREATE TABLE Student (
    ID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    education VARCHAR(255) NOT NULL,
    image VARCHAR(MAX) NULL
);
GO

-- Create the 'Sections' table
CREATE TABLE Sections (
    ID INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    link VARCHAR(255) NOT NULL,
    number INT NOT NULL UNIQUE,
    course_id INT,
    FOREIGN KEY (course_id) REFERENCES Course(ID) ON DELETE CASCADE
);
GO

-- Create the 'Teach' table (junction table between Instructor and Course)
CREATE TABLE Teach (
    Instructor_id INT,
    Course_id INT,
    PRIMARY KEY (Instructor_id, Course_id),
    FOREIGN KEY (Instructor_id) REFERENCES Instructor(ID) ON DELETE CASCADE,
    FOREIGN KEY (Course_id) REFERENCES Course(ID) ON DELETE CASCADE
);
GO

-- Create the 'Enroll' table (junction table between Student and Course)
CREATE TABLE Enroll (
    Course_id INT,
    Student_id INT,
    progress INT NULL,
    PRIMARY KEY (Course_id, Student_id),
    FOREIGN KEY (Course_id) REFERENCES Course(ID) ON DELETE CASCADE,
    FOREIGN KEY (Student_id) REFERENCES Student(ID) ON DELETE CASCADE
);
GO
