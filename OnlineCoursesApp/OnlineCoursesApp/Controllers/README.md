# Controller

## InstructorController

The `InstructorController` is responsible for handling all actions related to **Instructors** in the system. It enables instructors to manage their profile, view and manage their courses, and view students enrolled in their courses.

### Key Features and Endpoints:

#### 1. **Index (int id)**
- **URL**: `/Instructor/Index/{id}`
- **Description**: Displays the list of courses taught by the instructor.
- **Parameters**: 
  - `id`: The ID of the instructor.
- **Implementation**:
  - Fetches the instructor's data using the `_instructorService`, including related `Techs` and their associated `Courses`.
  - For each course, it calculates the number of students enrolled (`Enrollments`), along with course status and type.
  - Returns a list of courses to the view.
- **View**: Displays the instructor's courses and their associated details.

#### 2. **Students (int id)**
- **URL**: `/Instructor/Students/{id}`
- **Description**: Displays the list of students enrolled in a specific course.
- **Parameters**:
  - `id`: The ID of the course.
- **Implementation**:
  - Fetches the course and its associated `Enrollments` and `StudentProgress` to list all students enrolled in that course.
  - For each student, it shows the student's name and progress (percentage of completed sections).
  - Passes the course name and instructor ID to the view using `ViewData`.
- **View**: Displays a list of students along with their progress in the course.

#### 3. **Profile (int id)**
- **URL**: `/Instructor/Profile/{id}`
- **Description**: Displays the profile details of an instructor.
- **Parameters**:
  - `id`: The ID of the instructor.
- **Implementation**:
  - Fetches the instructor's basic details like `Name`, `Email`, `About`, and `Image`.
  - Passes this information to the view through a `InstructorProfileViewModel`.
- **View**: Displays the instructor’s profile information.

#### 4. **NewCourse**
- **URL**: `/Instructor/NewCourse`
- **Description**: Displays a view for the instructor to add a new course.
- **View**: A form for adding a new course (to be implemented).

#### 5. **Manage**
- **URL**: `/Instructor/Manage`
- **Description**: Displays a view for managing instructor-related tasks (to be implemented).
- **View**: A placeholder view for instructor management actions.

#### 6. **AddSection**
- **URL**: `/Instructor/AddSection`
- **Description**: Displays a view for adding a new section to a course.
- **View**: A form for adding sections to a course (to be implemented).

#### 7. **EditSection**
- **URL**: `/Instructor/EditSection`
- **Description**: Displays a view for editing an existing section of a course.
- **View**: A form for editing course sections (to be implemented).

---

### Dependencies

The controller relies on several services injected through the constructor to perform its operations:

1. **`IService<Instructor>`**: Handles instructor-related database operations.
2. **`IService<Tech>`**: Manages the relationships between instructors and their courses.
3. **`IService<Course>`**: Manages course data, including enrolled students and their progress.

---

This documentation provides an overview of the `InstructorController` and its key features, endpoints, and dependencies.