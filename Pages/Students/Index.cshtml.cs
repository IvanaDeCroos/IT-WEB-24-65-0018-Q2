using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            if (searchString != null)
            {
                SearchString = searchString;
            }

            CurrentFilter = SearchString;

            var students = from s in _context.Students.Include(s => s.Course)
                           select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Name.Contains(SearchString) ||
                                              s.City.Contains(SearchString));
            }

            Students = await students.ToListAsync();
        }
    }
}
