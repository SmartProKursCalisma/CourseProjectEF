using CourseProjectEF.Entities;
using System.Data.Entity;

namespace CourseProjectEF.DbCotntext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Server=202-00;Database=CourseProjectDb;User Id=sa;Password=1234;") { }

        public DbSet<Student> Students{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
