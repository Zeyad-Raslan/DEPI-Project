USE [OnlineCourseDemo]
GO
SET IDENTITY_INSERT [dbo].[Instructors] ON 

INSERT [dbo].[Instructors] ([InstructorId], [Name], [Email], [Password], [About], [Image]) VALUES (1, N'Mark Johnson', N'mark.johnson@example.com', N'instructorpass', N'Senior Instructor of Web Development', N'image1.jpg')
INSERT [dbo].[Instructors] ([InstructorId], [Name], [Email], [Password], [About], [Image]) VALUES (2, N'Lisa White', N'lisa.white@example.com', N'mypassword', N'Expert in Data Science', N'image2.jpg')
SET IDENTITY_INSERT [dbo].[Instructors] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [Image], [InstructorId], [CourseStatus]) VALUES (1, N'Web Development Bootcamp', N'Online', N'Comprehensive course on web development', N'webdev.jpg', 1, 0)
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [Image], [InstructorId], [CourseStatus]) VALUES (2, N'Data Science Essentials', N'Online', N'Learn the basics of Data Science', N'datasci.jpg', 2, 1)
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [Image], [InstructorId], [CourseStatus]) VALUES (3, N'Introduction to Programming', N'Beginner', N'Learn the fundamentals of programming.', N'programming-image.jpg', 1, 0)
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [Image], [InstructorId], [CourseStatus]) VALUES (4, N'Advanced Database Systems', N'Intermediate', N'Explore advanced database concepts.', N'database-image.jpg', 2, 1)
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [Image], [InstructorId], [CourseStatus]) VALUES (5, N'Web Development with React', N'Advanced', N'Master React for building web applications.', N'react-image.jpg', 1, 1)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [Name], [Email], [Password], [Education], [Image]) VALUES (1, N'Alice Brown', N'alice.brown@example.com', N'alicepass', N'Bachelor of Science', N'alice.jpg')
INSERT [dbo].[Students] ([StudentId], [Name], [Email], [Password], [Education], [Image]) VALUES (2, N'Tom Harris', N'tom.harris@example.com', N'tompass', N'Master of Computer Science', N'tom.jpg')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (1, 1)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (2, 1)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (3, 1)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (4, 1)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (5, 1)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (1, 2)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (2, 2)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (3, 2)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (4, 2)
INSERT [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId]) VALUES (5, 2)
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (1, N'Introduction to Web Development', N'link1', 1, 1)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (2, N'HTML Basics', N'link2', 2, 1)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (3, N'Introduction to Data Science', N'link3', 1, 2)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (4, N'Python for Data Science', N'link4', 2, 2)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (9, N'Introduction to C#', N'https://example.com/c-sharp-tutorial', 1, 1)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (10, N'Advanced C# Concepts', N'https://example.com/advanced-c-sharp', 2, 1)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (11, N'Web Development with ASP.NET Core', N'https://example.com/aspnet-core', 3, 2)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (12, N'Database Design and SQL', N'https://example.com/database-design', 4, 2)
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (13, N'Data Structures and Algorithms', N'https://example.com/data-structures', 5, 1)
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentProgresses] ON 

INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (2, 0, 2, 2, 1)
INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (3, 0, 1, 2, 3)
INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (4, 0, 1, 2, 4)
INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (5, 0, 1, 2, 11)
INSERT [dbo].[StudentProgresses] ([Id], [Status], [StudentId], [CourseId], [SectionId]) VALUES (6, 0, 1, 2, 12)
SET IDENTITY_INSERT [dbo].[StudentProgresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([ID], [Name], [Email], [Password]) VALUES (1, N'John Doe', N'john.doe@example.com', N'password123')
INSERT [dbo].[Admins] ([ID], [Name], [Email], [Password]) VALUES (2, N'Jane Smith', N'jane.smith@example.com', N'securepass')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
INSERT [dbo].[BlackLists] ([Email]) VALUES (N'blacklisted1@example.com')
INSERT [dbo].[BlackLists] ([Email]) VALUES (N'blacklisted2@example.com')
GO
