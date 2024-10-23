USE [OnlineCourseDemoSeed]
GO
SET IDENTITY_INSERT [dbo].[Instructors] ON 
GO
INSERT [dbo].[Instructors] ([InstructorId], [Name], [Email], [AccountStatus], [About], [Image], [IdentityUserID]) VALUES (-1, N'instructor Seed', N'instructor@mail.com', 1, NULL, N'/image/Instructor/default.png', N'413bf88a-2a9a-47fb-8e40-3783d55ab68e')
GO
INSERT [dbo].[Instructors] ([InstructorId], [Name], [Email], [AccountStatus], [About], [Image], [IdentityUserID]) VALUES (1, N'Osama El zero', N'osama@mail.com', 0, N'Programming', N'/image/Instructor/default.png', N'd6f5dec6-f6b0-4748-a18e-11458996b27d')
GO
INSERT [dbo].[Instructors] ([InstructorId], [Name], [Email], [AccountStatus], [About], [Image], [IdentityUserID]) VALUES (2, N'Free Code Camp', N'freeCode@mail.com', 0, N'Programming', N'/image/Instructor/default.png', N'c059e038-872c-4b68-a922-024d4cafbf71')
GO
SET IDENTITY_INSERT [dbo].[Instructors] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [CourseStatus], [Image], [InstructorId]) VALUES (1, N'new course 1', 2, N'dfdff', 3, N'/image/new good and bad habits.jpg', -1)
GO
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [CourseStatus], [Image], [InstructorId]) VALUES (2, N'Fundamentals Of Programming With C++', 0, N'learn the different fundamentals of programming using C++ programming language', 1, N'/image/download.jfif', 1)
GO
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [CourseStatus], [Image], [InstructorId]) VALUES (3, N'Mastering Python', 3, N'Master the programming language of python', 1, N'/image/zero_pyton.png', 1)
GO
INSERT [dbo].[Courses] ([CourseId], [Name], [Type], [Description], [CourseStatus], [Image], [InstructorId]) VALUES (4, N'Front End Developer Roadmap 2024', 2, N'Learn what technologies you should learn first to become a front end web developer.
Watch the full learning front end learning path', 2, N'/image/freeCodeCamp.org - Front End Developer Roadmap 2024 [9He4UBLyk8Y - 853x480 - 0m00s].png', 2)
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (1, N'mportant Introduction About The Course', N'https://youtu.be/XDuWyYxksXU?si=Ju50JTunO7Kcc0xg', 1, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (2, N'Why C++ Language', N'https://youtu.be/jOUb09iiO20?si=K_yzLdQ7oy1l8UfR', 2, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (3, N'Install VSC Editor, Compiler And Debugger', N'https://youtu.be/R-Hu5rdn-vc?si=2ZraRwxcYlOn_3cZ', 3, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (4, N' Install Visual Studio And Answer Questions', N'https://youtu.be/RWtT07Id-n4?si=qa0ZQ4UESmAYUUYx', 4, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (5, N'How The C++ Works', N'https://youtu.be/FVV4kTy0dJg?si=plXs-9W5dc6r5sIU', 5, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (6, N' Preprocessing, Compiling And Linking', N'https://youtu.be/1K1sET8dDrI?si=FGPQjDmY3xEGcyrh', 6, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (7, N'C++ Language Syntax', N'https://youtu.be/NeHu899_uYA?si=hc8T5wnyKY8PrUL1', 7, 2)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (8, N'Introduction And What''s Python ', N'https://youtu.be/mvZHDpCHphk?si=x7Mai8vJ43XdZQ49', 1, 3)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (9, N'HTML Tutorial - Website Crash Course for Beginners ', N'https://youtu.be/916GWv2Qs08?si=7KxupqpaVSCpGxyB', 1, 4)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (10, N'CSS Tutorial – Full Course for Beginners ', N'https://youtu.be/OXGznpKZ_sA?si=wGCtxIi2xZnK5SB1', 2, 4)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (11, N'Visual Studio Code Crash Course ', N'https://youtu.be/WPqXP_kLzpo?si=7zHHZTqpVut83mXW', 3, 4)
GO
INSERT [dbo].[Sections] ([SectionId], [Title], [Link], [Number], [CourseId]) VALUES (12, N'JavaScript Programming - Full Course ', N'https://youtu.be/jS4aFq5-91M?si=LwyE2se39WPW0dAx', 4, 4)
GO
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
