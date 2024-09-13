using System.ComponentModel.DataAnnotations;

namespace CourseProjectEF.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string NameSurname { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public int GradeId { get; set; }
    }
}
