namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int CourseId { get; set; }

        // Navigation property for related course
        public Course? Course { get; set; }
    }
}