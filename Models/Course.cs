namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;

        // Navigation property for related students
        public List<Student> Students { get; set; } = new List<Student>();
    }
}