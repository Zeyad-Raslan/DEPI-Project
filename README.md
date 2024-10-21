
# Online Course Platform

## Introduction
The **Online Course Platform** is designed to provide a flexible and accessible solution for online education. It enables **students** to enroll in online courses, **instructors** to upload and manage their courses, and **admins** to monitor the platform’s activities, offering a bridge between learners and digital education.

### Objectives:
- Provide a centralized, flexible online learning environment.
- Enable instructors to effectively manage and update their courses.
- Facilitate student progress tracking and course enrollment.

## Project Scope
### Problem:
The demand for online education platforms has increased significantly due to the constraints of traditional, in-person learning environments.

### Solution:
This platform offers an all-in-one solution where **instructors** can easily upload courses, and **students** can access and engage with educational content.

---

## System Overview

### Functional Requirements:
- **Students**:  
  - View and enroll in available courses.
  - Track course progress.
  
- **Instructors**:  
  - Create, edit, and delete courses.
  - View student enrollments and progress.
  
- **Admins**:  
  - Manage users (students, instructors).
  - Review and approve courses before publishing.

### Non-Functional Requirements:
- **Performance**: The system is designed to handle multiple simultaneous users efficiently.
- **Security**: Ensures data protection for users and course content.
- **Usability**: Provides a user-friendly interface for all users.

---

## System Architecture
This platform is built following the **3-Layer Architecture**:

1. **Presentation Layer**:  
   Manages the UI/UX for students, instructors, and admins.
   
2. **Business Logic Layer**:  
   Handles the main functionality such as course management, user interaction, and course approval.
   
3. **Data Access Layer**:  
   Communicates with the **SQL Server** database to retrieve and store data.

---

## Technology Stack
- **Language**: C#
- **Framework**: ASP.NET Core MVC
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **UI**: Bootstrap for responsive design

---

## Database Design
The platform’s database structure follows the ERD as shown below, illustrating the relationships between entities such as **Students**, **Instructors**, **Courses**, and more.

### ERD Diagram
![ERD Diagram](Resources/image/Capture.PNG)

### Schema Diagram
The schema diagram represents the detailed structure of the database.

![Schema Diagram](Resources/image/Database.PNG)

---

## User Interface Design
The platform has different interfaces for its users:

1. **Login and Registration**:  
   Users can create accounts and log in according to their roles (student, instructor, admin).
   
2. **Course Listing**:  
   Students can browse and enroll in courses.
   
3. **Student Dashboard**:  
   Displays enrolled courses and progress tracking.
   
4. **Instructor Dashboard**:  
   Allows course management and interaction with students.
   
5. **Admin Dashboard**:  
   Full control over user management and course approval.

---

## User Interaction
- **Students**:  
  - Can browse and enroll in courses.
  - Can track their progress in enrolled courses.
  
- **Instructors**:  
  - Can create, edit, and manage courses.
  - Monitor students' progress and engagement.
  
- **Admins**:  
  - Can manage both instructors and students.
  - Review and approve courses before publishing.
