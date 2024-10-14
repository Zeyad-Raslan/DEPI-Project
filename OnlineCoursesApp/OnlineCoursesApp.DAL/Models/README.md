# Online Courses Management System

This project is a basic **Online Courses Management System** implemented using ASP.NET Core MVC and Entity Framework. The system models various entities like courses, instructors, students, sections, and enrollments.

## Entities Overview

### 1. **Course**
- Represents an individual course in the system.
- Key Properties:
  - `ID`: Unique identifier for the course.
  - `Name`: Name of the course.
  - `Type`: Type of the course (e.g., online, in-person).
  - `Description`: Short description of the course.
  - `Image`: Optional image for the course.
  - `Status`: Status of the course (e.g., under review, approved).
- **Relationships**:
  - A course can have multiple enrollments (`Enroll`).
  - A course can have multiple technologies (`Tech`).
  - A course can have multiple sections (`Section`).
  - A course tracks student progress (`StudentProgress`).

### 2. **Enroll**
- Represents the enrollment of a student in a course (Many-to-Many relationship between `Student` and `Course`).
- Key Properties:
  - `StudentID`: Foreign key referring to the enrolled student.
  - `CourseID`: Foreign key referring to the enrolled course.

### 3. **Instructor**
- Represents an instructor who teaches one or more courses.
- Key Properties:
  - `ID`: Unique identifier for the instructor.
  - `Name`: Instructor's name.
  - `Email`: Instructor's email (must be unique).
  - `Password`: Password for account authentication.
  - `About`: Brief biography of the instructor.
  - `Image`: Optional profile image.
- **Relationships**:
  - An instructor can teach multiple courses via technologies (`Tech`).

### 4. **Section**
- Represents a section or part of a course.
- Key Properties:
  - `ID`: Unique identifier for the section.
  - `CourseID`: Foreign key referring to the course to which the section belongs.
  - `Title`: Title of the section.
  - `Link`: URL link to the section content.
  - `Num`: Number of the section in sequence.
- **Relationships**:
  - A section belongs to a course and can track students' progress (`StudentProgress`).

### 5. **Student**
- Represents a student who enrolls in courses.
- Key Properties:
  - `ID`: Unique identifier for the student.
  - `Name`: Student's name.
  - `Email`: Student's email (must be unique).
  - `Password`: Password for account authentication.
  - `Education`: Student's educational background.
  - `Image`: Optional profile image.
- **Relationships**:
  - A student can enroll in multiple courses (`Enroll`).
  - A student can track their progress in different sections (`StudentProgress`).

### 6. **StudentProgress**
- Tracks the progress of a student in a course section.
- Key Properties:
  - `ID`: Unique identifier for the progress.
  - `CourseID`: Foreign key referring to the course.
  - `StudentID`: Foreign key referring to the student.
  - `SectionID`: Foreign key referring to the section.
  - `IsCompleted`: Indicates whether the student has completed the section.

### 7. **Tech**
- Represents the relationship between an instructor and a course, i.e., the instructor teaching a particular course.
- Key Properties:
  - `InstructorID`: Foreign key referring to the instructor.
  - `CourseID`: Foreign key referring to the course.

## Database Context
The **OnlineCoursesDbContext** class manages the database context for the system. It defines DbSet properties for each of the entities and configures the relationships in the `OnModelCreating` method.

### Relationships:
- **Many-to-Many** between `Student` and `Course` (via `Enroll`).
- **Many-to-Many** between `Instructor` and `Course` (via `Tech`).
- **One-to-Many** between `Course` and `Section`.
- **One-to-Many** between `Section` and `StudentProgress`.

## Unique Constraints
- The `Email` field for both `Student` and `Instructor` entities is unique to avoid duplication.

## Default Values
- The `Status` field in the `Course` entity has a default value of `UnderReview`.
- The `IsCompleted` field in the `StudentProgress` entity has a default value of `false`.

---
