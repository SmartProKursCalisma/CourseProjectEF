using CourseProjectEF.DbCotntext;
using CourseProjectEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public bool AddStudent(Student student)
        {
            //_context.Entry(student).State = EntityState.Added;
            //Bu kod ekleme işlemi yapmakta. State Değişikliğinden sonra saveChanges() Çalıştırılmalı.
            _context.Students.Add(student);
            int affectedRows = _context.SaveChanges();
            int id = student.Id;
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }
        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(X => X.Id == id);
            //_context.Entry(student).State = EntityState.Deleted;
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            //_context.Entry(student).State = EntityState.Modified;
            var currentStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            currentStudent.NameSurname = student.NameSurname;
            currentStudent.PhoneNumber = student.PhoneNumber;
            currentStudent.GradeId = student.GradeId;
            //var currentUser = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            //_context.Entry(currentUser).CurrentValues.SetValues(student);
            _context.SaveChanges();
        }
        public Student GetStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }
        public List<Grade> Grades()
        {
            var grades = _context.Grades.ToList();
            return grades;
        }
    }
}
