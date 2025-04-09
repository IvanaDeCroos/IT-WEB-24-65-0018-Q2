using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int StudentCount { get; set; }
        public int CourseCount { get; set; }

        public void OnGet()
        {
            StudentCount = _context.Students.Count();
            CourseCount = _context.Courses.Count();
        }
    }
}