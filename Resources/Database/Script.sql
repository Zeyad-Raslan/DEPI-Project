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





--### Inserting Data into the `Instructor` Table

INSERT INTO Instructor (name, email, password, about, image) VALUES
('Dr. John Doe', 'john.doe@example.com', 'password123', 'Expert in Data Science', 'https://example.com/images/john_doe.jpg'),
('Jane Smith', 'jane.smith@example.com', 'securepassword', 'Specializes in Web Development', 'https://example.com/images/jane_smith.jpg');


--### Inserting Data into the `Course` Table

INSERT INTO Course (name, type, description, status, image) VALUES
('Introduction to Data Science', 'Online', 'Learn the basics of data science and analytics.', 1, 'https://example.com/images/data_science.jpg'),
('Web Development Bootcamp', 'Online', 'A comprehensive course on modern web development.', 1, 'https://example.com/images/web_dev.jpg');


--### Inserting Data into the `Student` Table

INSERT INTO Student (name, email, password, education, image) VALUES
('Alice Brown', 'alice.brown@example.com', 'password456', 'Bachelor of Science in Computer Science', 'https://example.com/images/alice_brown.jpg'),
('Bob Johnson', 'bob.johnson@example.com', 'mypassword', 'Bachelor of Arts in Design', 'https://example.com/images/bob_johnson.jpg');


-- ### Inserting Data into the `Sections` Table

INSERT INTO Sections (title, link, number, course_id) VALUES
('Introduction to Data Science', 'https://example.com/course1/section1', 1, 1),
('Data Analysis Techniques', 'https://example.com/course1/section2', 2, 1),
('HTML Basics', 'https://example.com/course2/section1', 1, 2),
('CSS Fundamentals', 'https://example.com/course2/section2', 2, 2);


--### Inserting Data into the `Teach` Table

INSERT INTO Teach (Instructor_id, Course_id) VALUES
(1, 1),  -- Dr. John Doe teaches Introduction to Data Science
(2, 2);  -- Jane Smith teaches Web Development Bootcamp


--### Inserting Data into the `Enroll` Table

INSERT INTO Enroll (Course_id, Student_id, progress) VALUES
(1, 1, 20),  -- Alice Brown is enrolled in Introduction to Data Science with 20% progress
(2, 2, 50),  -- Bob Johnson is enrolled in Web Development Bootcamp with 50% progress
(1, 2, NULL); -- Bob Johnson also enrolled in Introduction to Data Science with no progress recorded yet


