using CourseProjectEF.DbCotntext;
using CourseProjectEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectEF.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService()
        {
            _context = new AppDbContext();
        }
        public List<Student> SearchStudent(string searchTerm)
        {
           var users = _context
                .Students
                .Where(x => x.NameSurname.StartsWith(searchTerm))
                .ToList();
            return users;
        }
        public List<Student> GetAllStudent()
        {
            return _context.Students.ToList();
        }
    }
}
