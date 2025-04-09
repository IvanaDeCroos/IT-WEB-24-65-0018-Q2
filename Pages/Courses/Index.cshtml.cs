using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> Courses { get; set; } = new List<Course>();

        [BindProperty(SupportsGet = true)]
        public string? CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            // Save the search string for pagination
            CurrentFilter = searchString;

            // Create the base query
            var coursesQuery = _context.Courses
                .Include(c => c.Students)
                .AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                coursesQuery = coursesQuery.Where(c =>
                    c.Name.Contains(searchString) ||
                    c.LecturerName.Contains(searchString));
            }

            // Get the final list
            Courses = await coursesQuery.ToListAsync();
        }
    }
}