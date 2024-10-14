using System.Collections.Generic;

namespace OnlineCoursesApp.ViewModel.AdminUsedModels
{
	public class ManageInstructorsViewModel
	{
		public int InstructorId { get; set; }
		public string Name { get; set; }
		public string Specialty { get; set; }
		public int CourseCount { get; set; }
	}

	public class CreateInstructorViewModel
	{
		public string Name { get; set; }
		public string Specialty { get; set; }
	}

	public class EditInstructorViewModel
	{
		public int InstructorId { get; set; }
		public string Name { get; set; }
		public string Specialty { get; set; }
	}

	public class InstructorDetailsViewModel
	{
		public int InstructorId { get; set; }
		public string Name { get; set; }
		public string Specialty { get; set; }
		public List<CourseViewModel> Courses { get; set; } // Assuming instructors are related to courses
	}
}
